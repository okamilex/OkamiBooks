using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkamiBooks.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult PostForBooks(int selectedId)
        {

            var users = 5;
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}