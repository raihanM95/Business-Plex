using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessPlex.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Search()
        {
            return View();
        }
    }
}