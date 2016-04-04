using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OkamiBooks.Models;
using OkamiBooks.Models.Entities;
using WebGrease.Css.Extensions;

namespace OkamiBooks.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetUsers()
        {
            var findUsers = new List<ApplicationUser>();
            var users = new List<ExportUser>();
            using (var context = new DatabaseContext())
            {
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.MyRole != "guest")
                    {
                        findUsers.Add(x);
                    }
                });
                findUsers.ForEach(x => 
                {

                    ServiceRibbon serviceRibbon = new ServiceRibbon();
                        bool medal1 = false;
                        bool medal2 = false;
                        bool medal3 = false;
                        bool medal4 = false;
                        bool medal5 = false;
                        context.ServiceRibbons.ForEach(sr =>
                        {
                            if (sr.Id != x.MedalsList) return;
                            serviceRibbon.MedalCommentator = sr.MedalCommentator;
                            serviceRibbon.MedalCritic = sr.MedalCritic;
                            serviceRibbon.MedalLiker = sr.MedalLiker;
                            serviceRibbon.MedalReader = sr.MedalReader;
                            serviceRibbon.MedalWriter = sr.MedalWriter;
                            serviceRibbon.ApplicationUser = sr.ApplicationUser;
                        });
                        context.MedalsCommentator.ForEach(mc =>
                        {
                            if (mc.Id == serviceRibbon.MedalCommentator)
                            {
                                medal1 = mc.IsReceived;
                            }
                        });
                        context.MedalsCritic.ToList().ForEach(mc =>
                        {
                            if (mc.Id == serviceRibbon.MedalCritic)
                            {
                                medal2 = mc.IsReceived;
                            }
                        });
                        context.MedalsLiker.ToList().ForEach(mc =>
                        {
                            if (mc.Id == serviceRibbon.MedalLiker)
                            {
                                medal3 = mc.IsReceived;
                            }
                        });
                        context.MedalsReader.ToList().ForEach(mc =>
                        {
                            if (mc.Id == serviceRibbon.MedalReader)
                            {
                                medal4 = mc.IsReceived;
                            }
                        });
                        context.MedalsWriter.ToList().ForEach(mc =>
                        {
                            if (mc.Id == serviceRibbon.MedalWriter)
                            {
                                medal5 = mc.IsReceived;
                            }
                        });
                        users.Add(new ExportUser {Id = x.Id, Email = x.Email, Medal1 = medal1, Medal2 = medal2, Medal3 = medal3, Medal4 = medal4, Medal5 = medal5});
                    
                });
            }
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PostForUser(string selectedId, string userName)
        {
            using (var context = new DatabaseContext())
            {
               
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        x.UserNameToGet = selectedId;
                    }
                });
                context.SaveChanges();

            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}