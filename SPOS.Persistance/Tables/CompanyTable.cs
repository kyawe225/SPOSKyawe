
namespace SPOS.Persistance.Tables
{
    public class CompanyTable:BaseTable
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Address { set; get; }
    }
}
