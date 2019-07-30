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
        //[HttpGet]
        //public ActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        public ActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryManager.AddCategory(category))
                {
                    ViewBag.SuccessMsg = "Saved";
                }
                else
                {
                    ViewBag.FailMsg = "Failed";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
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
                    ViewBag.SuccessMsg = "Updated";
                }
                else
                {
                    ViewBag.FailMsg = "Failed";
                }
            }
            else
            {
                ViewBag.FailMsg = "Validation Error";
            }

            return View(category);
        }

        public ActionResult Delete()
        {
            _category.ID = 1;
            _categoryManager.DeleteCategory(_category);

            return View();
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

            if (category.Code != null)
            {
                categories = categories.Where(c => c.Code.ToLower().Contains(category.Code.ToLower())).ToList();
            }
            if (category.Name != null)
            {
                categories = categories.Where(c => c.Name.ToLower().Contains(category.Name.ToLower())).ToList();
            }
            
            category.Categories = categories;
            return View(category);
        }
    }
}