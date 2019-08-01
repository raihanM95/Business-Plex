using BusinessPlex.Models.Models;
using BusinessPlex.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.BLL.BLL
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();

        public bool AddSupplier(Supplier supplier)
        {
            return _supplierRepository.AddSupplier(supplier);
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            return _supplierRepository.DeleteSupplier(supplier);
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            return _supplierRepository.UpdateSupplier(supplier);
        }

        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }

        public Supplier GetByID(Supplier supplier)
        {
            return _supplierRepository.GetByID(supplier);
        }
    }
}
