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
    public class HomeController : Controller
    {
        UserManager _userManager = new UserManager();
        private User _user = new User();
        private UserViewModel _userViewModel = new UserViewModel();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        // POST: New
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New([Bind(Exclude = "IsEmailVerified,ActivationCode")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "User");
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(UserViewModel userViewModel)
        {
            string Meggage = null;
            bool Status = false;
            //if (ModelState.IsValid)
            //{

            //}
            //return RedirectToAction("Index", "Home");

            User user = new User();
            user = Mapper.Map<User>(userViewModel);

            if (_userManager.Login(user) >= 0)
            {
                if (_userManager.Login(user) > 0)
                {
                    Status = true;
                    int timeout = _userViewModel.Remember ? 505600 : 20;

                    var cokie = new HttpCookie("Doctor", _userViewModel.UserName);
                    cokie.Expires = DateTime.Now.AddMinutes(timeout);
                    cokie.HttpOnly = true;
                    Response.Cookies.Add(cokie);

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    Meggage = "Account is not verified or Password incorrect ";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                Meggage = "This user doesn't exist";
                return RedirectToAction("Index", "Home");
            }

            //ViewBag.Message = Meggage;
            //ViewBag.Status = Status;
        }
    }
}
