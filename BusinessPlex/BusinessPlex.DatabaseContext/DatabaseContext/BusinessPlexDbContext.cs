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
        public DbSet<Category> Categories { set; get; }
        public DbSet<Product> Products { set; get; }
    }
}
