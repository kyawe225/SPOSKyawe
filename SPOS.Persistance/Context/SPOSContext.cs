using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SPOS.Persistance.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPOS.Persistance.Context
{
    public class SPOSContext:DbContext
    {
        public SPOSContext(DbContextOptions<SPOSContext> options) : base(options)
        {
            
        }
        public DbSet<Users> users { set; get; }
        public DbSet<CompanyTable> companies { set; get; }
        public DbSet<ProductTable> products { set; get; }
        public DbSet<OrderDetail> orderDetails { set; get; }
        public DbSet<OrderTable> orders { set; get; }
        public DbSet<ProductInventoryTable> productInventories { set; get; }
        public DbSet<InventoryTable> inventory { set; get; }

    }
}
