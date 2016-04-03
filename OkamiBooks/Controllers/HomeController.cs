using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OkamiBooks.Models;
using OkamiBooks.Models.Entities;

namespace OkamiBooks.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            using (var context = new DatabaseContext())
            {
                //context.Tags.Add(new Tags {Name = "first"});
                context.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetBestBooks()
        {

            var users = 5;
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetLastBooks()
        {

            var users = 5;
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCategories()
        {

            var users = 5;
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetTags()
        {

            var users = 5;
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostForBook(int selectedId)
        {

            var users = 5;
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostForTags(int selectedId)
        {

            var users = 5;
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostForCategories(int selectedId)
        {

            var users = 5;
            return Json(users, JsonRequestBehavior.AllowGet);
        }







    }
}