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
    public class CustomerRepository
    {
        BusinessPlexDbContext db = new BusinessPlexDbContext();
        public bool AddCustomer(Customer customer)
        {
            int isExecuted = 0;

            db.Customers.Add(customer);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool DeleteCustomer(Customer customer)
        {
            int isExecuted = 0;

            Customer aCustomer = db.Customers.FirstOrDefault(c => c.ID == customer.ID);

            db.Customers.Remove(aCustomer);
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            int isExecuted = 0;

            db.Entry(customer).State = EntityState.Modified;
            isExecuted = db.SaveChanges();

            if (isExecuted > 0)
            {
                return true;
            }

            return false;
        }

        public List<Customer> GetAll()
        {
            return db.Customers.ToList();
        }

        public Customer GetByID(Customer customer)
        {
            Customer aCustomer = db.Customers.FirstOrDefault(c => c.ID == customer.ID);

            return aCustomer;
        }
    }
}
