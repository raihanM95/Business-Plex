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
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();
        private Product _product = new Product();
        private ProductViewModel _productViewModel = new ProductViewModel();
        CategoryManager _categoryManager = new CategoryManager();

        // GET: Product
        [HttpGet]
        public ActionResult Add()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });
            
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(productViewModel.ImageFile.FileName);
                productViewModel.Image = productViewModel.Code + fileName + System.IO.Path.GetExtension(productViewModel.ImageFile.FileName);
                fileName = "~/images/ProductImages/" + productViewModel.Code + fileName + System.IO.Path.GetExtension(productViewModel.ImageFile.FileName);
                productViewModel.ImageFile.SaveAs(Server.MapPath(fileName));

                Product product = new Product();
                product = Mapper.Map<Product>(productViewModel);

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

            productViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            return View(productViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            _product.ID = id;
            var product = _productManager.GetByID(_product);
            _productViewModel = Mapper.Map<ProductViewModel>(product);

            _productViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            return View(_productViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(productViewModel.ImageFile.FileName);
                productViewModel.Image = productViewModel.Code + fileName + System.IO.Path.GetExtension(productViewModel.ImageFile.FileName);
                fileName = "~/images/ProductImages/" + productViewModel.Code + fileName + System.IO.Path.GetExtension(productViewModel.ImageFile.FileName);
                productViewModel.ImageFile.SaveAs(Server.MapPath(fileName));

                Product product = new Product();
                product = Mapper.Map<Product>(productViewModel);

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

            productViewModel.CategorySelectListItems = _categoryManager.GetAll().Select(c => new SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            return View(productViewModel);
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
            _productViewModel.Products = _productManager.GetAll();

            return View(_productViewModel);
        }

        [HttpPost]
        public ActionResult Show(ProductViewModel productViewModel)
        {
            var products = _productManager.GetAll();

            if (productViewModel.Name != null)
            {
                Product product = new Product();
                product = Mapper.Map<Product>(productViewModel);

                products = products.Where(c => c.Name.ToLower().Contains(product.Name.ToLower())).ToList();
            }

            productViewModel.Products = products;
            return View(productViewModel);
        }
    }
}
