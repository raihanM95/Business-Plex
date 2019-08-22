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
    public class ReportingController : Controller
    {
        ProductManager _productManager = new ProductManager();
        ReportingManager _reportingManager = new ReportingManager();
        PurchaseManager _purchseManager = new PurchaseManager();
        SalesManager _salesManager = new SalesManager();
        private Product _product = new Product();

        // GET: Reporting
        [HttpGet]
        public ActionResult PeriodictIncomeReport()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PeriodictIncomeReport(ProductViewModel productViewModel)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            List<ProductViewModel> productsPreviousRecord = new List<ProductViewModel>();

            var products = _productManager.GetAll();
            foreach (var product in products)
            {
                var aProduct = _purchseManager.GetByPrevious(product);
                productsPreviousRecord.Add(aProduct);
            }

            var salesProducts = _reportingManager.PeriodictIncomeReport(productViewModel);
            foreach (var saleProduct in salesProducts)
            {
                ProductViewModel model = new ProductViewModel();

                var product = productsPreviousRecord.Where(c => c.ProductId == saleProduct.ProductId).FirstOrDefault();
                _product.ID = product.ProductId;
                var aProduct = _productManager.GetByID(_product);
                model.Code = aProduct.Code;
                model.Name = aProduct.Name;
                model.CategoryName = aProduct.Category.Name;
                model.TotalCostPrice = product.PreviousCostPrice * saleProduct.Quantity;
                model.SalesPrice = product.PreviousMRP * saleProduct.Quantity;
                model.Profit = model.SalesPrice - model.TotalCostPrice;
                productViewModels.Add(model);
            }
            foreach (var model in productViewModels)
            {
                ProductViewModel aModel = new ProductViewModel();

                if (productViewModel.ProductsView!=null && productViewModel.ProductsView.Count > 0)
                {
                    int count = 0;
                    int countValue = productViewModel.ProductsView.Count;
                    foreach (var p in productViewModel.ProductsView)
                    {
                        count++;
                        if (p.Name == model.Name)
                        {
                            p.TotalCostPrice += model.TotalCostPrice;
                            p.SalesPrice += model.SalesPrice;
                            p.Profit += model.Profit;
                            break;
                        }
                        else
                        {
                            if (count == countValue)
                            {
                                aModel.Code = model.Code;
                                aModel.Name = model.Name;
                                aModel.CategoryName = model.CategoryName;
                                aModel.TotalCostPrice = model.TotalCostPrice;
                                aModel.SalesPrice = model.SalesPrice;
                                aModel.Profit = model.Profit;
                                productViewModel.ProductsView.Add(aModel);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    aModel.Code = model.Code;
                    aModel.Name = model.Name;
                    aModel.CategoryName = model.CategoryName;
                    aModel.TotalCostPrice = model.TotalCostPrice;
                    aModel.SalesPrice = model.SalesPrice;
                    aModel.Profit = model.Profit;
                    productViewModel.ProductsView.Add(aModel);
                }

            }
            return View(productViewModel);
        }

        [HttpGet]
        public ActionResult PeriodicIncomeExpenseOnPurchase()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PeriodicIncomeExpenseOnPurchase(ProductViewModel productViewModel)
        {
            List<ProductViewModel> productViewModels = new List<ProductViewModel>();
            List<ProductViewModel> productsPreviousRecord = new List<ProductViewModel>();

            var products = _productManager.GetAll();
            foreach (var product in products)
            {
                var aProduct = _purchseManager.GetByPrevious(product);
                productsPreviousRecord.Add(aProduct);
            }

            var purchaseProducts = _reportingManager.PeriodictIncomeReportOnPurchase(productViewModel);
            foreach (var purchaseProduct in purchaseProducts)
            {
                ProductViewModel model = new ProductViewModel();

                var product = productsPreviousRecord.Where(c => c.ProductId == purchaseProduct.ProductId).FirstOrDefault();
                _product.ID = product.ProductId;
                int availableQuantity = _salesManager.GetBySalesQuantity(_product);
                var aProduct = _productManager.GetByID(_product);
                model.Code = aProduct.Code;
                model.Name = aProduct.Name;
                model.CategoryName = aProduct.Category.Name;
                model.TotalCostPrice = product.PreviousCostPrice * availableQuantity;
                model.SalesPrice = product.PreviousMRP * availableQuantity;
                model.Profit = model.SalesPrice - model.TotalCostPrice;
                productViewModels.Add(model);
            }
            foreach (var model in productViewModels)
            {
                ProductViewModel aModel = new ProductViewModel();

                if (productViewModel.ProductsView != null && productViewModel.ProductsView.Count > 0)
                {
                    int count = 0;
                    int countValue = productViewModel.ProductsView.Count;
                    foreach (var p in productViewModel.ProductsView)
                    {
                        count++;
                        if (p.Name == model.Name)
                        {
                            p.TotalCostPrice += model.TotalCostPrice;
                            p.SalesPrice += model.SalesPrice;
                            p.Profit += model.Profit;
                            break;
                        }
                        else
                        {
                            if (count == countValue)
                            {
                                aModel.Code = model.Code;
                                aModel.Name = model.Name;
                                aModel.CategoryName = model.CategoryName;
                                aModel.TotalCostPrice = model.TotalCostPrice;
                                aModel.SalesPrice = model.SalesPrice;
                                aModel.Profit = model.Profit;
                                productViewModel.ProductsView.Add(aModel);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    aModel.Code = model.Code;
                    aModel.Name = model.Name;
                    aModel.CategoryName = model.CategoryName;
                    aModel.TotalCostPrice = model.TotalCostPrice;
                    aModel.SalesPrice = model.SalesPrice;
                    aModel.Profit = model.Profit;
                    productViewModel.ProductsView.Add(aModel);
                }

            }
            return View(productViewModel);
        }
    }
}