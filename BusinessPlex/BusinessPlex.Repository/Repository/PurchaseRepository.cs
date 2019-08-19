using BusinessPlex.DatabaseContext.DatabaseContext;
using BusinessPlex.Models;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Repository.Repository
{
    public class PurchaseRepository
    {
        BusinessPlexDbContext db = new BusinessPlexDbContext();
        public bool Entry(PurchaseSupplier purchaseSupplier)
        {
            int isExecuted = 0;

            db.PurchaseSuppliers.Add(purchaseSupplier);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public ProductViewModel GetByPrevious(Product product)
        {
            ProductViewModel aProduct = new ProductViewModel();
            var products = db.PurchaseDetails.Where(c => c.ProductId == product.ID).ToList();
            if (products.Count > 0)
            {
                int count = 0;
                int latestList = products.Count;
                foreach (var pro in products)
                {
                    count++;
                    if (latestList == count)
                    {
                        aProduct.ID = pro.ProductId;
                        aProduct.PreviousCostPrice = pro.UnitPrice;
                        aProduct.PreviousMRP = pro.MRP;
                    }
                }
            }
            return aProduct;
        }
    }
}
