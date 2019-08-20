using BusinessPlex.DatabaseContext.DatabaseContext;
using BusinessPlex.Models;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.Repository.Repository
{
    public class SalesRepository
    {
        BusinessPlexDbContext db = new BusinessPlexDbContext();
        public bool Entry(SalesCustomer salesCustomer)
        {
            int isExecuted = 0;

            db.SalesCustomers.Add(salesCustomer);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public int GetByPurchaseQuantity(Product product)
        {
            PurchaseViewModel aPurchase = new PurchaseViewModel();
            var purchase = db.PurchaseDetails.Where(c => c.ProductId == product.ID).ToList();
            if (purchase.Count > 0)
            {
                foreach (var pur in purchase)
                {
                    aPurchase.Quantity += pur.Quantity; 
                }
            }
            return aPurchase.Quantity;
        }

        public int GetBySalesQuantity(Product product)
        {
            SalesViewModel aSales = new SalesViewModel();
            var sales = db.SalesDetails.Where(c => c.ProductId == product.ID).ToList();
            if (sales.Count > 0)
            {
                foreach (var sal in sales)
                {
                    aSales.Quantity += sal.Quantity;
                }
            }
            return aSales.Quantity;
        }
    }
}
