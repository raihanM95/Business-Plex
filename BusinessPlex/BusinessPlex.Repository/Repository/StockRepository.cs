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
    public class StockRepository
    {
        BusinessPlexDbContext db = new BusinessPlexDbContext();

        public List<SalesDetails> DateWiseSearch(StockViewModel stockViewModel)
        {
            List<SalesDetails> salesDetails = new List<SalesDetails>();
            var saleProducts = db.SalesCustomers.Where(c => c.Date >= stockViewModel.StartDate && c.Date <= stockViewModel.EndDate).ToList();
            foreach (var product in saleProducts)
            {
                var saleProduct = db.SalesDetails.Include(c => c.Product).Where(c => c.SalesCustomerId == product.ID).FirstOrDefault();
                salesDetails.Add(saleProduct);
            }
            return salesDetails;
        }

        public StockViewModel GetByExpireDate(Product product)
        {
            StockViewModel aProduct = new StockViewModel();
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
                        aProduct.ProductId = pro.ProductId;
                        aProduct.ExpiredDate = pro.ExpireDate;
                    }
                }
            }
            return aProduct;
        }

        public int GetExpiredQuantity(Product product)
        {
            StockViewModel aStock = new StockViewModel();
            var purchase = db.PurchaseDetails.Where(c => c.ProductId == product.ID && c.ExpireDate <= DateTime.Now).ToList();
            if (purchase.Count > 0)
            {
                foreach (var pur in purchase)
                {
                    aStock.ExpiredQuantity += pur.Quantity;
                }
            }
            return aStock.ExpiredQuantity;
        }

        public int GetPreviousStockIn(Product product, StockViewModel stockViewModel)
        {
            int Quantity = 0;
            var purchaseProducts = db.PurchaseSuppliers.Where(c => c.Date <= stockViewModel.StartDate).ToList();
            if(purchaseProducts.Count > 0)
            {
                foreach (var pro in purchaseProducts)
                {
                    var purchaseProduct = db.PurchaseDetails.Include(c => c.Product).Where(c => c.ProductId == product.ID && c.PurchaseSupplierId == pro.ID).FirstOrDefault();
                    if(purchaseProduct != null)
                    {
                        Quantity += purchaseProduct.Quantity;
                    }
                }
            }
            return Quantity;
        }

        public int GetPreviousStockOut(Product product, StockViewModel stockViewModel)
        {
            int Quantity = 0;
            var saleProducts = db.SalesCustomers.Where(c => c.Date <= stockViewModel.StartDate).ToList();
            if (saleProducts.Count > 0)
            {
                foreach (var pro in saleProducts)
                {
                    var saleProduct = db.SalesDetails.Include(c => c.Product).Where(c => c.ProductId == product.ID && c.SalesCustomerId == pro.ID).FirstOrDefault();
                    if (saleProduct != null)
                    {
                        Quantity += saleProduct.Quantity;
                    }
                }
            }
            return Quantity;
        }

        public int GetStockIn(Product product, StockViewModel stockViewModel)
        {
            int Quantity = 0;
            var purchaseProducts = db.PurchaseSuppliers.Where(c => c.Date >= stockViewModel.StartDate && c.Date <= stockViewModel.EndDate).ToList();
            if(purchaseProducts.Count > 0)
            {
                foreach (var pro in purchaseProducts)
                {
                    var purchaseProduct = db.PurchaseDetails.Include(c => c.Product).Where(c => c.ProductId == product.ID && c.PurchaseSupplierId == pro.ID).FirstOrDefault();
                    if (purchaseProduct != null)
                    {
                        Quantity += purchaseProduct.Quantity;
                    }
                }
            }
            return Quantity;
        }

        public int GetStockOut(Product product, StockViewModel stockViewModel)
        {
            int Quantity = 0;
            var saleProducts = db.SalesCustomers.Where(c => c.Date >= stockViewModel.StartDate && c.Date <= stockViewModel.EndDate).ToList();
            if(saleProducts.Count > 0)
            {
                foreach (var pro in saleProducts)
                {
                    var saleProduct = db.SalesDetails.Include(c => c.Product).Where(c => c.ProductId == product.ID && c.SalesCustomerId == pro.ID).FirstOrDefault();
                    if (saleProduct != null)
                    {
                        Quantity += saleProduct.Quantity;
                    }
                }
            }
            return Quantity;
        }
    }
}
