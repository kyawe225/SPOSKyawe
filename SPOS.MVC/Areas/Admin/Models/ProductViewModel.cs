namespace SPOS.MVC.Areas.Admin.Models
{
    public class ProductCreateViewModel
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public long Price { set; get; }
        public long NumberOfItems { set; get; }
        public string CompanyId { set; get; }
    }
    public class ProductListViewModel
    {
        public string Id { set; get; }
        public string Name { set; get; }
    }
}
