using BusinessPlex.BLL.BLL;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();
        private Supplier _supplier = new Supplier();

        // GET: Supplier
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (_supplierManager.AddSupplier(supplier))
                {
                    ViewBag.Message = "Saved";
                }
                else
                {
                    ViewBag.Message = "Failed";
                }
            }
            else
            {
                ViewBag.Message = "Validation Error";
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            _supplier.ID = Id;
            var supplier = _supplierManager.GetByID(_supplier);

            return View(supplier);
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (_supplierManager.UpdateSupplier(supplier))
                {
                    ViewBag.Message = "Updated";
                }
                else
                {
                    ViewBag.Message = "Failed";
                }
            }
            else
            {
                ViewBag.Message = "Validation Error";
            }

            return View(supplier);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _supplier.ID = id;
                if (_supplierManager.DeleteSupplier(_supplier))
                {
                    ViewBag.AlertMsg = "Delete Successfully";
                }
                return RedirectToAction("Show");
            }
            catch
            {
                return RedirectToAction("Show"); ;
            }
        }

        [HttpGet]
        public ActionResult Show()
        {
            _supplier.Suppliers = _supplierManager.GetAll();

            return View(_supplier);
        }

        [HttpPost]
        public ActionResult Show(Supplier supplier)
        {
            var Suppliers = _supplierManager.GetAll();

            //if (supplier.Search != null)
            //{
            //    Suppliers = Suppliers.Where(c => c.Search.ToLower().Contains(supplier.Code.ToLower())).ToList();
            //}
            if (supplier.Name != null)
            {
                Suppliers = Suppliers.Where(c => c.Name.ToLower().Contains(supplier.Name.ToLower())).ToList();
            }

            supplier.Suppliers = Suppliers;
            return View(supplier);
        }
    }
}
