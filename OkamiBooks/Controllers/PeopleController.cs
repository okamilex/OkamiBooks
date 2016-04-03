using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OkamiBooks.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult PostForUser(int selectedId)
        {

            var users = 5;
            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}