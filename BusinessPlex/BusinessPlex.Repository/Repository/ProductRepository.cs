using BusinessPlex.DatabaseContext.DatabaseContext;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Repository.Repository
{
    public class ProductRepository
    {
        BusinessPlexDbContext db = new BusinessPlexDbContext();
        public bool AddProduct(Product product)
        {
            int isExecuted = 0;

            db.Products.Add(product);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteProduct(Product product)
        {
            int isExecuted = 0;

            Product aProduct = db.Products.FirstOrDefault(c => c.ID == product.ID);

            db.Products.Remove(aProduct);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateProduct(Product product)
        {
            int isExecuted = 0;

            db.Entry(product).State = EntityState.Modified;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetByID(Product product)
        {
            Product aProduct = db.Products.FirstOrDefault(c => c.ID == product.ID);

            return aProduct;
        }
    }
}
