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
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();
        private Customer _customer = new Customer();
        private CustomerViewModel _customerViewModel = new CustomerViewModel();

        // GET: Customer
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(customerViewModel.ImageFile.FileName);
                customerViewModel.Image = customerViewModel.Code + fileName + System.IO.Path.GetExtension(customerViewModel.ImageFile.FileName);
                fileName = "~/images/CustomerImages/" + customerViewModel.Code + fileName + System.IO.Path.GetExtension(customerViewModel.ImageFile.FileName);
                customerViewModel.ImageFile.SaveAs(Server.MapPath(fileName));

                Customer customer = new Customer();
                customer = Mapper.Map<Customer>(customerViewModel);

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
        public ActionResult Edit(int id)
        {
            _customer.ID = id;
            var customer = _customerManager.GetByID(_customer);
            _customerViewModel = Mapper.Map<CustomerViewModel>(customer);

            return View(_customerViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(customerViewModel.ImageFile.FileName);
                customerViewModel.Image = customerViewModel.Code + fileName + System.IO.Path.GetExtension(customerViewModel.ImageFile.FileName);
                fileName = "~/images/CustomerImages/" + customerViewModel.Code + fileName + System.IO.Path.GetExtension(customerViewModel.ImageFile.FileName);
                customerViewModel.ImageFile.SaveAs(Server.MapPath(fileName));

                Customer customer = new Customer();
                customer = Mapper.Map<Customer>(customerViewModel);

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

            return View(customerViewModel);
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
            _customerViewModel.Customers = _customerManager.GetAll();

            return View(_customerViewModel);
        }

        [HttpPost]
        public ActionResult Show(CustomerViewModel customerViewModel)
        {
            var customers = _customerManager.GetAll();

            if (customerViewModel.Name != null)
            {
                Customer customer = new Customer();
                customer = Mapper.Map<Customer>(customerViewModel);

                customers = customers.Where(c => c.Name.ToLower().Contains(customer.Name.ToLower())).ToList();
            }

            customerViewModel.Customers = customers;
            return View(customerViewModel);
        }
    }
}
