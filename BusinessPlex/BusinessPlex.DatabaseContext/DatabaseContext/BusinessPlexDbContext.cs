using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.DatabaseContext.DatabaseContext
{
    public class BusinessPlexDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Supplier> Suppliers { set; get; }
        public DbSet<PurchaseSupplier> PurchaseSuppliers { get; set; }
        public DbSet<PurchaseDetails> PurchaseDetails { get; set; }
    }
}
