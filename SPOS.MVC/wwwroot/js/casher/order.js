let saveButton = document.getElementById("save-order")
let itemLists = [];
const defaultItemOrder = 1;



const calcSubTotal = (price, items) => {
    return price * items;
}
const calcTotal = (subTotals = null) => {
    let total = 0
    console.log(subTotals.length);
    subTotals.forEach((value, index, array) => {
        total += value.subTotal;
    });
    return total;
};

const calcRechangeAmmount = (pay_ammount) => {
    let total = calcTotal(itemLists);
    if (parseInt(pay_ammount) > 0 && parseInt(pay_ammount) >= total) {
        return parseInt(pay_ammount) - total; 
    }
    return '';
}

saveButton.addEventListener("click", (ev) => {
    let serialNu = document.getElementById("pd-serial-no").value;
    let name = document.getElementById("pd-name").value;
    let price = document.getElementById("pd-price").value;
    let items = document.getElementById("pd-items").value;
    let index = itemLists.length + 1;
    let subTotal = calcSubTotal(price, items);
    let row = document.createElement("tr");
    let col1 = document.createElement('td');
    col1.appendChild(document.createTextNode(index));
    let col2 = document.createElement('td');
    col2.appendChild(document.createTextNode("aaabbb"));
    let col3 = document.createElement('td');
    col3.appendChild(document.createTextNode(serialNu));
    let col4 = document.createElement('td');
    col4.appendChild(document.createTextNode(name));
    let col5 = document.createElement('td');
    col5.appendChild(document.createTextNode(items));
    let col6 = document.createElement('td');
    col6.appendChild(document.createTextNode(price));
    let col7 = document.createElement('td');
    col7.appendChild(document.createTextNode(subTotal));
    let col8 = document.createElement('td');
    let delButton = document.createElement('button');
    delButton.type = "button";
    delButton.innerText = "Delete";
    delButton.name = "del-but"
    delButton.classList.add("btn", "btn-danger");
    delButton.value = index;
    col8.appendChild(delButton);

    row.appendChild(col1);
    row.appendChild(col2);
    row.appendChild(col3);
    row.appendChild(col4);
    row.appendChild(col5);
    row.appendChild(col6);
    row.appendChild(col7);
    row.appendChild(col8);
    let body = document.getElementById("order-body");
    body.appendChild(row);
    itemLists.push({ subTotal: subTotal, rowNo: itemLists.length + 1, id: serialNu, item: items, price: price });
    let total = calcTotal(itemLists);
    console.log(total);
    document.getElementById("price-column").innerHTML = total;
    delButton.addEventListener('click', function (ev) {
        itemLists=itemLists.filter((value) => { return value.rowNo!= ev.target.value });
        let total = calcTotal(itemLists);
        document.getElementById("price-column").innerHTML = total;
        ev.target.parentNode.parentNode.parentNode.removeChild(ev.target.parentNode.parentNode);
        if (document.getElementById("pay-input").value > 0) {
            document.getElementById("rechange-input").value = calcRechangeAmmount(document.getElementById("pay-input").value);
        }
    });
     document.getElementById("pd-serial-no").value="";
     document.getElementById("pd-name").value="";
     document.getElementById("pd-price").value="";
     document.getElementById("pd-items").value="";
    document.getElementById("pd-sub").value = "";
    saveButton.disabled = true;
});
let searchButton = document.getElementById("pd-search");
searchButton.addEventListener('click', function (ev) {
    let serial = document.getElementById("pd-serial").value;
    if (!serial) {
        console.error("Please Fill the Serial Number");
    }
    $.ajax({
        url: "/product/findproduct/" + serial,
        type: 'post',
        success: (result, status, xhr) => {
            let serialNu = document.getElementById("pd-serial-no");
            let name = document.getElementById("pd-name");
            let price = document.getElementById("pd-price");
            let items = document.getElementById("pd-items");
            let subTotal = document.getElementById("pd-sub");
            serialNu.value = result.data.id;
            name.value = result.data.name;
            price.value = result.data.price;
            items.value = defaultItemOrder;
            subTotal.value = calcSubTotal(result.data.price, defaultItemOrder);
            saveButton.disabled = false;
            saveButton.classList.remove('disabled');
        },
        error: (result, status, error) => {
            console.log(error);
        }
    });
});

document.getElementById("pd-items").addEventListener("keyup", function (ev) {
    let price = document.getElementById("pd-price").value;
    let subTotal = 0;
    if (parseInt(ev.target.value) > 0 && parseInt(price) > 0) {
        console.log("hello its here");
        subTotal = parseInt(ev.target.value) * parseInt(price);
    }
    document.getElementById("pd-sub").value = subTotal;
});

document.getElementById("finish-order").addEventListener('click', (ev) => {
    if (itemLists.length > 0 && parseInt(document.getElementById('rechange-input').value) >=0) {
        let ids = [];
        for (let i of itemLists) {
            let obj = {
                id: i.id,
                number_of_items: i.item,
                price: i.price
            };
            ids.push(obj);
        }
        console.log(ids);
        $.ajax({
            url: "/order/accept",
            type: "post",
            data: { ids: ids },
            success: (result, xhr, status) => {
                //window.location.reload();
                document.getElementById("modal-text").innerText = "Successfully Ordered";
                $("#c-modal").modal('show');
                ids = [];
            },
            error: (xhr, error) => {
                console.error("Some Error Found");
            }
        });
    }
    
});

document.getElementById("pay-input").addEventListener("keyup", (ev) => {
    document.getElementById("rechange-input").value = calcRechangeAmmount(ev.target.value);
    return;
});

document.getElementById("close-btn").addEventListener('click', function (ev) {
    $("#c-modal").modal('hide');
    window.location.reload();
})