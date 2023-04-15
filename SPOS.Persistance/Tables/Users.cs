
namespace SPOS.Persistance.Tables
{
    public class Users:BaseTable
    {
        public string Password { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Adress { set; get; }
        public string NRC { set; get; }
    }
}
