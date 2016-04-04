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
            string userName = "";
            long accsessToken = 0;
            using (var context = new DatabaseContext())
            {
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.Email == userEmail)
                    {
                        if (x.PasswordHash == userPassword)
                        {
                            userName = x.UserName;
                            accsessToken = x.AcsesToken = new Random().Next(1, 100000);
                        }
                        else
                        {
                            code = 409;
                        }
                    }
                });
            }
            var resolt = new List<string>();
            resolt.Add(code.ToString());
            resolt.Add(userName);
            resolt.Add(accsessToken.ToString());
            return Json(resolt, JsonRequestBehavior.AllowGet);
        }
    }
}