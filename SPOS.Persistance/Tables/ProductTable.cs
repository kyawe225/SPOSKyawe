using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOS.Persistance.Tables
{
    public class ProductTable:BaseTable
    {
        public string Name { set; get; }
        public string Description { set; get; }
        public long Price { set; get; }
        public Guid CompanyId { set; get; }
        [ForeignKey("CompanyId")]
        public virtual CompanyTable? Company { set; get; }
        public long NumberOfItems { set; get; }
    }
}
