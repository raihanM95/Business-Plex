using BusinessPlex.Models.Models;
using BusinessPlex.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.BLL.BLL
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();

        public bool Entry(SalesCustomer salesCustomer)
        {
            return _salesRepository.Entry(salesCustomer);
        }
    }
}
