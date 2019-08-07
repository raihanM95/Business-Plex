using AutoMapper;
using BusinessPlex.BLL.BLL;
using BusinessPlex.Models;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();
        private Supplier _supplier = new Supplier();
        private SupplierViewModel _supplierViewModel = new SupplierViewModel();

        // GET: Supplier
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(SupplierViewModel supplierViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(supplierViewModel.ImageFile.FileName);
                supplierViewModel.Image = supplierViewModel.Code + fileName + System.IO.Path.GetExtension(supplierViewModel.ImageFile.FileName);
                fileName = "~/images/SupplierLogo/" + supplierViewModel.Code + fileName + System.IO.Path.GetExtension(supplierViewModel.ImageFile.FileName);
                supplierViewModel.ImageFile.SaveAs(Server.MapPath(fileName));

                Supplier supplier = new Supplier();
                supplier = Mapper.Map<Supplier>(supplierViewModel);

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
        public ActionResult Edit(int id)
        {
            _supplier.ID = id;
            var supplier = _supplierManager.GetByID(_supplier);
            _supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);

            return View(_supplierViewModel);
        }

        [HttpPost]
        public ActionResult Edit(SupplierViewModel supplierViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(supplierViewModel.ImageFile.FileName);
                supplierViewModel.Image = supplierViewModel.Code + fileName + System.IO.Path.GetExtension(supplierViewModel.ImageFile.FileName);
                fileName = "~/images/SupplierLogo/" + supplierViewModel.Code + fileName + System.IO.Path.GetExtension(supplierViewModel.ImageFile.FileName);
                supplierViewModel.ImageFile.SaveAs(Server.MapPath(fileName));

                Supplier supplier = new Supplier();
                supplier = Mapper.Map<Supplier>(supplierViewModel);

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

            return View(supplierViewModel);
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
            _supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(_supplierViewModel);
        }

        [HttpPost]
        public ActionResult Show(SupplierViewModel supplierViewModel)
        {
            var suppliers = _supplierManager.GetAll();

            if (supplierViewModel.Name != null)
            {
                Supplier supplier = new Supplier();
                supplier = Mapper.Map<Supplier>(supplierViewModel);

                suppliers = suppliers.Where(c => c.Name.ToLower().Contains(supplier.Name.ToLower())).ToList();
            }

            supplierViewModel.Suppliers = suppliers;
            return View(supplierViewModel);
        }
    }
}
