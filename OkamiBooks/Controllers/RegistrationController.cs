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
                ApplicationUser applicationUser = new ApplicationUser();
                
                context.ApplicationUsers.ForEach(x =>
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
                    context.ApplicationUsers.Add(applicationUser = new ApplicationUser());
                    applicationUser.Books = "";
                    applicationUser.Comments = "";
                    applicationUser.Likes = "";
                    applicationUser.BookInfos = "";
                    applicationUser.Email = userEmail;
                    applicationUser.UserName = userEmail;
                    applicationUser.PasswordHash = userPassword;
                    applicationUser.MyRole = "user";
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
                    sr.MedalCommentator = context.IdSaviors.ToList()[0].MaxMedalCommentator;
                    sr.MedalCritic = context.IdSaviors.ToList()[0].MaxMedalCritic;
                    sr.MedalLiker = context.IdSaviors.ToList()[0].MaxMedalLiker;
                    sr.MedalReader = context.IdSaviors.ToList()[0].MaxMedalReader;
                    sr.MedalWriter = context.IdSaviors.ToList()[0].MaxMedalWriter;
                    context.ServiceRibbons.Add(sr);
                    applicationUser.MedalsList = context.IdSaviors.ToList()[0].MaxServiceRibbon++;
                    
                    sr.ApplicationUser = userEmail;
                }
                context.SaveChanges();
            }
            return Json(new {Code = code}, JsonRequestBehavior.AllowGet);
        }
    }
}