using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkamiBooks.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        [Authorize]
        public ActionResult MyAcount()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult People()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}