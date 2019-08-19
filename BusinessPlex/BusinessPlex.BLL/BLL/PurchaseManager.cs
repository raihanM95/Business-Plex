using BusinessPlex.Models.Models;
using BusinessPlex.Models;
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

        public bool Entry(PurchaseSupplier purchaseSupplier)
        {
            return _purchaseRepository.Entry(purchaseSupplier);
        }

        public ProductViewModel GetByPrevious(Product product)
        {
            return _purchaseRepository.GetByPrevious(product);
        }
    }
}
