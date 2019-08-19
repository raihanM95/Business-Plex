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
    public class SalesController : Controller
    {
        SalesManager _salesManager = new SalesManager();
        private SalesCustomer _salesCustomer = new SalesCustomer();
        CustomerManager _customerManager = new CustomerManager();
        ProductManager _productManager = new ProductManager();

        // GET: Sales
        [HttpGet]
        public ActionResult Entry()
        {
            SalesViewModel salesViewModel = new SalesViewModel();
            salesViewModel.CustomerSelectListItems = _customerManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            salesViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            return View(salesViewModel);
        }

        [HttpPost]
        public ActionResult Entry(SalesViewModel salesViewModel)
        {
            if (ModelState.IsValid)
            {
                _salesCustomer.CustomerId = salesViewModel.CustomerId;
                _salesCustomer.Date = salesViewModel.Date;
                _salesCustomer.LoyaltyPoint = salesViewModel.LoyaltyPoint;
                _salesCustomer.SalesDetails = salesViewModel.SalesDetails;

                if (_salesManager.Entry(_salesCustomer))
                {
                    ViewBag.Message = "Saved";

                    salesViewModel.CustomerSelectListItems = _customerManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    });

                    salesViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    });

                    return View(salesViewModel);
                }
            }
            
            return View(salesViewModel);
        }

        public JsonResult GetLoyaltyPoint(int customerId)
        {
            Customer customer = new Customer();
            customer.ID = customerId;
            var aCustomer = _customerManager.GetByID(customer);
            int loyaltyPoint = aCustomer.LoyaltyPoint;

            return Json(loyaltyPoint, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetAvailableQuantity(int productId)
        //{
        //    Product product = new Product();
        //    product.ID = productId;
        //    var aProduct = _productManager.GetByID(product);
        //    int loyaltyPoint = aProduct.Q;

        //    return Json(loyaltyPoint, JsonRequestBehavior.AllowGet);
        //}
    }
}