namespace SPOS.MVC.Models
{
    public class OrderDetailCreateViewModel
    {
        public string id { set; get; }
        public long number_of_items { set; get; }
        public long price { set; get; }
    }
    public class OrderCreateViewModel
    {
        public ICollection<OrderDetailCreateViewModel> products { set; get; }
    }
}
