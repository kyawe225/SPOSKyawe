namespace SPOS.MVC.Areas.Admin.Models
{
    public class InventoryCreateViewModel
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public long NumberOfItems { set; get; }
        public DateTime ArrivedDate { set; get; }
        public bool Perishable { set; get; }
        public DateTime? ExpireDate { set; get; }
        public bool isSellable { set; get; }
        public bool isQualified { set; get; }
        public string ProductId { set; get; }
    }
    public class InventoryApproveViewModel : InventoryCreateViewModel
    {
        public string Id { set; get; }
        public string productName { set; get; }
        public string companyId { set; get; }
        public string companyName { set; get; }
    }
}
