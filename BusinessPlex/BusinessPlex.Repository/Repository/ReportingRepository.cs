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
    public class ReportingRepository
    {
        BusinessPlexDbContext db = new BusinessPlexDbContext();

        public List<SalesDetails> PeriodictIncomeReport(ProductViewModel productViewModel)
        {
            List<SalesDetails> salesDetails = new List<SalesDetails>();
            var saleProducts = db.SalesCustomers.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
            foreach (var product in saleProducts)
            {
                var saleProduct = db.SalesDetails.Include(c => c.Product).Where(c => c.SalesCustomerId == product.ID).FirstOrDefault();
                salesDetails.Add(saleProduct);
            }
            return salesDetails;
        }

        public List<PurchaseDetails> PeriodictIncomeReportOnPurchase(ProductViewModel productViewModel)
        {
            List<PurchaseDetails> purchaseDetails = new List<PurchaseDetails>();
            var purchaseProducts = db.PurchaseSuppliers.Where(c => c.Date >= productViewModel.StartDate && c.Date <= productViewModel.EndDate).ToList();
            foreach (var product in purchaseProducts)
            {
                var purchaseProduct = db.PurchaseDetails.Include(c => c.Product).Where(c => c.PurchaseSupplierId == product.ID).FirstOrDefault();
                purchaseDetails.Add(purchaseProduct);
            }
            return purchaseDetails;
        }
    }
}
