using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SPOS.Persistance.Tables
{
    public class OrderDetail:BaseTable
    {
        public string Name { set; get; }=Guid.NewGuid().ToString();
        public Guid ProductId { set; get; }
        public Guid OrderId { set; get; }
        [ForeignKey("OrderId")]
        public virtual OrderTable? Order { set; get; }
        [ForeignKey("ProductId")]
        public virtual ProductTable? Product { set; get; }
        public long SubTotalPrice { set; get; }
        public long Items { set; get; }
    }
}
