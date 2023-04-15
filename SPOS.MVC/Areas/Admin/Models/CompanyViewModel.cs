namespace SPOS.MVC.Areas.Admin.Models
{
    public class CompanyCreateViewModel
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Address { set; get; }
    }
    public class CompanyListViewModel
    {
        public string Id { set; get; }
        public string Name { set; get; }
    }
}
