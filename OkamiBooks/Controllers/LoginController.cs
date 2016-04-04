using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkamiBooks.Models;
using WebGrease.Css.Extensions;

namespace OkamiBooks.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult RegistrationOfNewUser(string userEmail, string userPassword)
        {
            var code = 200;
            long userId = -1;
            long accsessToken = 0;
            using (var context = new DatabaseContext())
            {
                context.MyUsers.ForEach(x =>
                {
                    if (x.Email == userEmail)
                    {
                        if (x.HashedPassword == userPassword)
                        {
                            userId = x.Id;
                            accsessToken = x.AcsesToken = new Random().Next(1, 100000);
                        }
                    }
                });
            }
            var resolt = new List<long>();
            resolt.Add(userId);
            resolt.Add(accsessToken);
            return Json(resolt, JsonRequestBehavior.AllowGet);
        }
    }
}