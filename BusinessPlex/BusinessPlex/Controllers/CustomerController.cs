using BusinessPlex.BLL.BLL;
using BusinessPlex.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();
        private Customer _customer = new Customer();

        // GET: Customer
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (_customerManager.AddCustomer(customer))
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
            _customer.ID = Id;
            var customer = _customerManager.GetByID(_customer);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                if (_customerManager.UpdateCustomer(customer))
                {
                    ViewBag.Message = "Updated";
                    return RedirectToAction("Show");
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

            return View(customer);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _customer.ID = id;
                if (_customerManager.DeleteCustomer(_customer))
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
            _customer.Customers = _customerManager.GetAll();

            return View(_customer);
        }

        [HttpPost]
        public ActionResult Show(Customer customer)
        {
            var customers = _customerManager.GetAll();

            //if (customer.Search != null)
            //{
            //    customers = customers.Where(c => c.Search.ToLower().Contains(customer.Code.ToLower())).ToList();
            //}
            if (customer.Name != null)
            {
                customers = customers.Where(c => c.Name.ToLower().Contains(customer.Name.ToLower())).ToList();
            }

            customer.Customers = customers;
            return View(customer);
        }
    }
}
