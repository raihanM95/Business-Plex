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
    public class SupplierRepository
    {
        BusinessPlexDbContext db = new BusinessPlexDbContext();
        public bool AddSupplier(Supplier supplier)
        {
            int isExecuted = 0;

            db.Suppliers.Add(supplier);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            int isExecuted = 0;

            Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.ID == supplier.ID);

            db.Suppliers.Remove(aSupplier);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            int isExecuted = 0;

            db.Entry(supplier).State = EntityState.Modified;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public Supplier GetByID(Supplier supplier)
        {
            Supplier aSupplier = db.Suppliers.FirstOrDefault(c => c.ID == supplier.ID);

            return aSupplier;
        }
    }
}
