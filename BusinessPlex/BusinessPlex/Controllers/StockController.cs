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
        //SalesManager _salesManager = new SalesManager();
        StockManager _stockManager = new StockManager();
        //PurchaseManager _purchseManager = new PurchaseManager();
        private StockViewModel _stockViewModel = new StockViewModel();
        private Product _product = new Product();

        // GET: Stock
        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(StockViewModel stockViewModel)
        {
            List<StockViewModel> stockViewModels = new List<StockViewModel>();
            List<StockViewModel> getRecord = new List<StockViewModel>();

            var products = _productManager.GetAll();
            
            if (stockViewModel.ProductName != null || stockViewModel.CategoryName != null)
            {
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
                //stockViewModel.Products = products;

                foreach (var product in products)
                {
                    var aProduct = _stockManager.GetByExpireDate(product);
                    getRecord.Add(aProduct);
                }

                if(stockViewModel.StartDate == null || stockViewModel.EndDate == null)
                {
                    stockViewModel.StartDate = Convert.ToDateTime("04/08/2019");
                    stockViewModel.EndDate = DateTime.Now;
                }
                var salesProducts = _stockManager.DateWiseSearch(stockViewModel);

                foreach (var model in salesProducts)
                {
                    StockViewModel aModel = new StockViewModel();
                    var product = getRecord.Where(c => c.ProductId == model.ProductId).FirstOrDefault();
                    if(product != null)
                    {
                        _product.ID = product.ProductId;
                        var aProduct = _productManager.GetByID(_product);
                        if (stockViewModel.Stocks != null && stockViewModel.Stocks.Count > 0)
                        {
                            int count = 0;
                            int countValue = stockViewModel.Stocks.Count;
                            foreach (var p in stockViewModel.Stocks)
                            {
                                count++;
                                if (p.ProductId != model.ProductId)
                                {
                                    aModel.ProductId = aProduct.ID;
                                    aModel.ProductCode = aProduct.Code;
                                    aModel.ProductName = aProduct.Name;
                                    aModel.CategoryName = aProduct.Category.Name;
                                    aModel.ReorderLevel = aProduct.ReorderLevel;
                                    aModel.ExpiredDate = product.ExpiredDate;
                                    aModel.ExpiredQuantity = _stockManager.GetExpiredQuantity(_product);
                                    aModel.OpeningBalance = _stockManager.GetPreviousStockIn(_product, stockViewModel) - _stockManager.GetPreviousStockOut(_product, stockViewModel);
                                    aModel.StockIn = _stockManager.GetStockIn(_product, stockViewModel);
                                    aModel.StockOut = _stockManager.GetStockOut(_product, stockViewModel);
                                    aModel.ClosingBalance = aModel.OpeningBalance + aModel.StockIn - aModel.StockOut;
                                    stockViewModel.Stocks.Add(aModel);
                                    break;
                                }
                                else
                                {
                                    if (count == countValue)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            aModel.ProductId = aProduct.ID;
                            aModel.ProductCode = aProduct.Code;
                            aModel.ProductName = aProduct.Name;
                            aModel.CategoryName = aProduct.Category.Name;
                            aModel.ReorderLevel = aProduct.ReorderLevel;
                            aModel.ExpiredDate = product.ExpiredDate;
                            aModel.ExpiredQuantity = _stockManager.GetExpiredQuantity(_product);
                            aModel.OpeningBalance = _stockManager.GetPreviousStockIn(_product, stockViewModel) - _stockManager.GetPreviousStockOut(_product, stockViewModel);
                            aModel.StockIn = _stockManager.GetStockIn(_product, stockViewModel);
                            aModel.StockOut = _stockManager.GetStockOut(_product, stockViewModel);
                            aModel.ClosingBalance = aModel.OpeningBalance + aModel.StockIn - aModel.StockOut;
                            stockViewModel.Stocks.Add(aModel);
                        }
                    }
                }
            }
            else
            {
                foreach (var product in products)
                {
                    var aProduct = _stockManager.GetByExpireDate(product);
                    getRecord.Add(aProduct);
                }

                var salesProducts = _stockManager.DateWiseSearch(stockViewModel);

                foreach (var model in salesProducts)
                {
                    StockViewModel aModel = new StockViewModel();
                    var product = getRecord.Where(c => c.ProductId == model.ProductId).FirstOrDefault();
                    _product.ID = product.ProductId;
                    var aProduct = _productManager.GetByID(_product);
                    if (stockViewModel.Stocks != null && stockViewModel.Stocks.Count > 0)
                    {
                        int count = 0;
                        int countValue = stockViewModel.Stocks.Count;
                        foreach (var p in stockViewModel.Stocks)
                        {
                            count++;
                            if (p.ProductId != model.ProductId)
                            {
                                aModel.ProductId = aProduct.ID;
                                aModel.ProductCode = aProduct.Code;
                                aModel.ProductName = aProduct.Name;
                                aModel.CategoryName = aProduct.Category.Name;
                                aModel.ReorderLevel = aProduct.ReorderLevel;
                                aModel.ExpiredDate = product.ExpiredDate;
                                aModel.ExpiredQuantity = _stockManager.GetExpiredQuantity(_product);
                                aModel.OpeningBalance = _stockManager.GetPreviousStockIn(_product, stockViewModel) - _stockManager.GetPreviousStockOut(_product, stockViewModel);
                                aModel.StockIn = _stockManager.GetStockIn(_product, stockViewModel);
                                aModel.StockOut = _stockManager.GetStockOut(_product, stockViewModel);
                                aModel.ClosingBalance = aModel.OpeningBalance + aModel.StockIn - aModel.StockOut;
                                stockViewModel.Stocks.Add(aModel);
                                break;
                            }
                            else
                            {
                                if (count == countValue)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        aModel.ProductId = aProduct.ID;
                        aModel.ProductCode = aProduct.Code;
                        aModel.ProductName = aProduct.Name;
                        aModel.CategoryName = aProduct.Category.Name;
                        aModel.ReorderLevel = aProduct.ReorderLevel;
                        aModel.ExpiredDate = product.ExpiredDate;
                        aModel.ExpiredQuantity = _stockManager.GetExpiredQuantity(_product);
                        aModel.OpeningBalance = _stockManager.GetPreviousStockIn(_product, stockViewModel) - _stockManager.GetPreviousStockOut(_product, stockViewModel);
                        aModel.StockIn = _stockManager.GetStockIn(_product, stockViewModel);
                        aModel.StockOut = _stockManager.GetStockOut(_product, stockViewModel);
                        aModel.ClosingBalance = aModel.OpeningBalance + aModel.StockIn - aModel.StockOut;
                        stockViewModel.Stocks.Add(aModel);
                    }
                }
            }
            return View(stockViewModel);
        }
    }
}