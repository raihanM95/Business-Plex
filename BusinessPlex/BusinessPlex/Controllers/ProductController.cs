using BusinessPlex.BLL.BLL;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Controllers
{
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();
        private Product _product = new Product();

        // GET: Product
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                if (_productManager.AddProduct(product))
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
            _product.ID = Id;
            var product = _productManager.GetByID(_product);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (_productManager.UpdateProduct(product))
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

            return View(product);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _product.ID = id;
                if (_productManager.DeleteProduct(_product))
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
            _product.Products = _productManager.GetAll();

            return View(_product);
        }

        [HttpPost]
        public ActionResult Show(Product product)
        {
            var products = _productManager.GetAll();

            //if (product.Search != null)
            //{
            //    products = products.Where(c => c.Search.ToLower().Contains(product.Code.ToLower())).ToList();
            //}
            if (product.Name != null)
            {
                products = products.Where(c => c.Name.ToLower().Contains(product.Name.ToLower())).ToList();
            }

            product.Products = products;
            return View(product);
        }
    }
}
