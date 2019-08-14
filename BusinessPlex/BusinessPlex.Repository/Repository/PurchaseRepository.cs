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
    public class PurchaseRepository
    {
        BusinessPlexDbContext db = new BusinessPlexDbContext();
        public bool Entry(PurchaseSupplier purchaseSupplier, List<PurchaseDetails> purchaseDetails)
        {
            int isExecuted = 0;

            db.PurchaseSuppliers.Add(purchaseSupplier);
            db.PurchaseDetails.AddRange(purchaseDetails);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        //public bool DeletePurchase(PurchaseDetails purchaseDetails)
        //{
        //    int isExecuted = 0;

        //    PurchaseDetails aPurchaseDetails = db.PurchaseDetails.FirstOrDefault(c => c.ID == purchaseDetails.ID);

        //    db.PurchaseDetails.Remove(aPurchaseDetails);
        //    isExecuted = db.SaveChanges();

        //    if (isExecuted > 0)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public bool Update(PurchaseSupplier purchaseSupplier, PurchaseDetails purchaseDetails)
        {
            int isExecuted = 0;

            db.Entry(purchaseSupplier).State = EntityState.Modified;
            db.Entry(purchaseDetails).State = EntityState.Modified;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<PurchaseDetails> GetAll()
        {
            return db.PurchaseDetails.ToList();
        }

        public PurchaseDetails GetByID(PurchaseDetails purchaseDetails)
        {
            PurchaseDetails aPurchaseDetails = db.PurchaseDetails.FirstOrDefault(c => c.ID == purchaseDetails.ID);

            return aPurchaseDetails;
        }

        public PurchaseDetails GetByPrevious(PurchaseDetails purchaseDetails)
        {
            PurchaseDetails aPurchaseDetails = db.PurchaseDetails.FirstOrDefault(c => c.ProductId == purchaseDetails.ProductId);

            return aPurchaseDetails;
        }
    }
}
