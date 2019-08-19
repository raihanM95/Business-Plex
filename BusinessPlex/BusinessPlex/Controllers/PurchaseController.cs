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
    public class PurchaseController : Controller
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        private PurchaseSupplier _purchaseSupplier = new PurchaseSupplier();
        SupplierManager _supplierManager = new SupplierManager();
        ProductManager _productManager = new ProductManager();

        // GET: Purchase
        [HttpGet]
        public ActionResult Entry()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.SupplierSelectListItems = _supplierManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            purchaseViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            return View(purchaseViewModel);
        }

        [HttpPost]
        public ActionResult Entry(PurchaseViewModel purchaseViewModel)
        {
            if (ModelState.IsValid)
            {
                _purchaseSupplier.InvoiceNo = purchaseViewModel.InvoiceNo;
                _purchaseSupplier.Date = purchaseViewModel.Date;
                _purchaseSupplier.SupplierId = purchaseViewModel.SupplierId;
                _purchaseSupplier.PurchaseDetails = purchaseViewModel.PurchaseDetails;
                if (_purchaseManager.Entry(_purchaseSupplier))
                {
                    ViewBag.Message = "Saved";

                    purchaseViewModel.SupplierSelectListItems = _supplierManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    });

                    purchaseViewModel.ProductSelectListItems = _productManager.GetAll().Select(c => new SelectListItem()
                    {
                        Value = c.ID.ToString(),
                        Text = c.Name
                    });

                    return View(purchaseViewModel);
                }
            }
            return View(purchaseViewModel);
        }

        public JsonResult GetProductHistory(int productId)
        {
            ProductViewModel model = new ProductViewModel();
            Product product = new Product();
            product.ID = productId;
            var aProduct = _productManager.GetByID(product);
            string productCode = aProduct.Code;
            
            model = _purchaseManager.GetByPrevious(product);
            model.Code = productCode;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
