using BusinessPlex.Models;
using BusinessPlex.Models.Models;
using BusinessPlex.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessPlex.BLL.BLL
{
    public class StockManager
    {
        StockRepository _stockRepository = new StockRepository();

        public List<SalesDetails> DateWiseSearch(StockViewModel stockViewModel)
        {
            return _stockRepository.DateWiseSearch(stockViewModel);
        }

        public StockViewModel GetByExpireDate(Product product)
        {
            return _stockRepository.GetByExpireDate(product);
        }

        public int GetExpiredQuantity(Product product)
        {
            return _stockRepository.GetExpiredQuantity(product);
        }
        
        public int GetPreviousStockIn(Product product, StockViewModel stockViewModel)
        {
            return _stockRepository.GetPreviousStockIn(product, stockViewModel);
        }

        public int GetPreviousStockOut(Product product, StockViewModel stockViewModel)
        {
            return _stockRepository.GetPreviousStockOut(product, stockViewModel);
        }

        public int GetStockIn(Product product, StockViewModel stockViewModel)
        {
            return _stockRepository.GetStockIn(product, stockViewModel);
        }

        public int GetStockOut(Product product, StockViewModel stockViewModel)
        {
            return _stockRepository.GetStockOut(product, stockViewModel);
        }
    }
}
