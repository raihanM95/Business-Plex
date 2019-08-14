using BusinessPlex.Models.Models;
using BusinessPlex.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.BLL.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public bool Entry(PurchaseSupplier purchaseSupplier, List<PurchaseDetails> purchaseDetails)
        {
            return _purchaseRepository.Entry(purchaseSupplier, purchaseDetails);
        }

        //public bool DeleteSupplier(PurchaseDetails purchaseDetails)
        //{
        //    return _purchaseRepository.DeletePurchase(purchaseDetails);
        //}

        public bool Update(PurchaseSupplier purchaseSupplier, PurchaseDetails purchaseDetails)
        {
            return _purchaseRepository.Update(purchaseSupplier, purchaseDetails);
        }

        public List<PurchaseDetails> GetAll()
        {
            return _purchaseRepository.GetAll();
        }

        public PurchaseDetails GetByID(PurchaseDetails purchaseDetails)
        {
            return _purchaseRepository.GetByID(purchaseDetails);
        }

        public PurchaseDetails GetByPrevious(PurchaseDetails purchaseDetails)
        {
            return _purchaseRepository.GetByPrevious(purchaseDetails);
        }
    }
}
