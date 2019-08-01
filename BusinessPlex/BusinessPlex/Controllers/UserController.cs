using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return RedirectToAction("Index", "User");
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
