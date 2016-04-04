using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkamiBooks.Models;
using OkamiBooks.Models.Entities;
using OkamiBooks.Models.Entities.Medals;
using WebGrease.Css.Extensions;

namespace OkamiBooks.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RegistrationOfNewUser(string userEmail, string userPassword)
        {
            int code = 200;
            using (var context = new DatabaseContext())
            {
                bool userExist = false;
                MyUser user = new MyUser();
                context.MyUsers.ForEach(x =>
                {
                    if (x.Email == userEmail)
                    {
                        userExist = true;
                    }
                });
                if (userExist)
                {
                    code = 409;
                }
                else
                {
                    user.Email = userEmail;
                    user.HashedPassword = userPassword;
                    user.Role = "user";
                    ServiceRibbon sr = new ServiceRibbon();
                    MedalCommentator medalCommentator = new MedalCommentator();
                    MedalCritic medalCritic = new MedalCritic();
                    MedalLiker medalLiker = new MedalLiker();
                    MedalReader medalReader = new MedalReader();
                    MedalWriter medalWriter = new MedalWriter();
                    context.MedalsCommentator.Add(medalCommentator);
                    context.MedalsCritic.Add(medalCritic);
                    context.MedalsLiker.Add(medalLiker);
                    context.MedalsReader.Add(medalReader);
                    context.MedalsWriter.Add(medalWriter);
                    sr.MedalCommentator = medalCommentator.Id;
                    sr.MedalCritic = medalCritic.Id;
                    sr.MedalLiker = medalLiker.Id;
                    sr.MedalReader = medalReader.Id;
                    sr.MedalWriter = medalWriter.Id;
                    context.ServiceRibbons.Add(sr);
                    user.MedalsList = sr.Id;
                    context.MyUsers.Add(user);
                    sr.User = user.Id;
                }
            }
            return Json(new {Code = code}, JsonRequestBehavior.AllowGet);
        }
    }
}