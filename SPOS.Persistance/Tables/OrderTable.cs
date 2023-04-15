using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOS.Persistance.Tables
{
    public class OrderTable : BaseTable
    {
        public string Name { set; get; }
        public virtual IEnumerable<OrderDetail>? Details { set; get; }
        public long TotalPrice { set; get; }
        public long TotalTax { set; get; }
        //public Guid UserId { set; get; }
        //[ForeignKey("UserId")]
        //public virtual Users? User { set; get; }
    }
}
