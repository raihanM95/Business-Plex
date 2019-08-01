using BusinessPlex.BLL.BLL;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        private Category _category = new Category();

        // GET: Category
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryManager.AddCategory(category))
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
            _category.ID = Id;
            var category = _categoryManager.GetByID(_category);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryManager.UpdateCategory(category))
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

            return View(category);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _category.ID = id;
                if (_categoryManager.DeleteCategory(_category))
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
            _category.Categories = _categoryManager.GetAll();

            return View(_category);
        }

        [HttpPost]
        public ActionResult Show(Category category)
        {
            var categories = _categoryManager.GetAll();

            //if (category.Search != null)
            //{
            //    categories = categories.Where(c => c.Search.ToLower().Contains(category.Code.ToLower())).ToList();
            //}
            if (category.Name != null)
            {
                categories = categories.Where(c => c.Name.ToLower().Contains(category.Name.ToLower())).ToList();
            }
            
            category.Categories = categories;
            return View(category);
        }
    }
}
