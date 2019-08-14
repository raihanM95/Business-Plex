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
        private PurchaseDetails _purchaseDetails = new PurchaseDetails();
        private PurchaseViewModel _purchaseViewModel = new PurchaseViewModel();
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
            var purchaseDetails = new List<PurchaseDetails>();
            var purchaseSupplier = new PurchaseSupplier();

            if (ModelState.IsValid)
            {
                purchaseSupplier.Date = purchaseViewModel.Date;
                purchaseSupplier.InvoiceNo = purchaseViewModel.InvoiceNo;
                purchaseSupplier.SupplierId = Convert.ToInt32(purchaseViewModel.SupplierId);

                foreach (var details in purchaseViewModel.PurchaseDetails)
                {
                    details.PurchaseSupplierId = purchaseSupplier.ID;
                    
                    purchaseDetails.Add(details);
                }
            }

            _purchaseManager.Entry(purchaseSupplier, purchaseDetails);

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

        public JsonResult GetProductCode(int productId)
        {
            Product _product = new Product();
            _product.ID = productId;
            var product = _productManager.GetByID(_product);

            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByPrevious(int productId)
        {
            _purchaseDetails.ProductId = productId;
            var previous = _purchaseManager.GetByPrevious(_purchaseDetails);
            return Json(previous, JsonRequestBehavior.AllowGet);
        }
    }
}
