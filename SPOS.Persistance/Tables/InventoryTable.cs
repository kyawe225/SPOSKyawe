using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOS.Persistance.Tables
{
    public class InventoryTable:BaseTable
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public long NumberOfItems { set; get; }
        public DateTime ArrivedDate { set; get; }
        public bool Perishable { set; get; }=false;
        public DateTime? ExpireDate { set; get; }
        public bool isSellable { set; get; } = false;
        public bool isQualified { set; get; } = false;
        public Guid ProductId { set; get; }
        [ForeignKey("ProductId")]
        public virtual ProductTable? Product { set; get; }
    }
}
