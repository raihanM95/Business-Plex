using BusinessPlex.BLL.BLL;
using BusinessPlex.Models;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Controllers
{
    public class StockController : Controller
    {
        ProductManager _productManager = new ProductManager();
        private StockViewModel _stockViewModel = new StockViewModel();

        // GET: Stock
        [HttpGet]
        public ActionResult Search()
        {
            _stockViewModel.Products = _productManager.GetAll();

            return View(_stockViewModel);
        }

        [HttpPost]
        public ActionResult Search(StockViewModel stockViewModel)
        {
            var products = _productManager.GetAll();

            if (stockViewModel.ProductName != null)
            {
                Product product = new Product();
                product.Name = stockViewModel.ProductName;

                products = products.Where(c => c.Name.ToLower().Contains(product.Name.ToLower())).ToList();
            }
            if (stockViewModel.CategoryName != null)
            {
                Category category = new Category();
                category.Name = stockViewModel.CategoryName;

                products = products.Where(c => c.Category.Name.ToLower().Contains(category.Name.ToLower())).ToList();
            }

            stockViewModel.Products = products;
            return View(stockViewModel);
        }
    }
}