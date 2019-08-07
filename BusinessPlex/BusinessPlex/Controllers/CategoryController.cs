using AutoMapper;
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
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        private Category _category = new Category();
        private CategoryViewModel _categoryViewModel = new CategoryViewModel();

        // GET: Category
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category = Mapper.Map<Category>(categoryViewModel);

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
        public ActionResult Edit(int id)
        {
            _category.ID = id;
            var category = _categoryManager.GetByID(_category);
            _categoryViewModel = Mapper.Map<CategoryViewModel>(category);

            return View(_categoryViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category = Mapper.Map<Category>(categoryViewModel);

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

            return View(categoryViewModel);
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
            _categoryViewModel.Categories = _categoryManager.GetAll();

            return View(_categoryViewModel);
        }

        [HttpPost]
        public ActionResult Show(CategoryViewModel categoryViewModel)
        {
            var categories = _categoryManager.GetAll();

            if (categoryViewModel.Name != null)
            {
                Category category = new Category();
                category = Mapper.Map<Category>(categoryViewModel);

                categories = categories.Where(c => c.Name.ToLower().Contains(category.Name.ToLower())).ToList();
            }

            categoryViewModel.Categories = categories;
            return View(categoryViewModel);
        }
    }
}
