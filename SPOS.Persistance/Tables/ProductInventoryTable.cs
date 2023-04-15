using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOS.Persistance.Tables
{
    public class ProductInventoryTable:BaseTable
    {
        public Guid ProductId { set; get; }
        public Guid InventoryId { set; get; }
        [ForeignKey("ProductId")]
        public virtual ProductTable? Product { set; get; }
        [ForeignKey("InventoryId")]
        public virtual InventoryTable? Inventory { set; get; }

    }
}
