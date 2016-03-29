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
        [HttpGet]
        public JsonResult GetAllUsers()
        {
            List<User> users;

            using (var context = new DatabaseContext())
            {
                
                users = context.Users.ToList();
            }
            return Json(users, JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            using (var context = new DatabaseContext())
            {
                var user = context.Users.Include(u => u.UserRole).FirstOrDefault();
                context.SaveChanges();
            }
            return View();
        }

        


        [Authorize]
        [Authorize(Roles = "Admin")]
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