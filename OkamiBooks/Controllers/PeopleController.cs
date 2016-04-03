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
            var users = new List<ExportUser>();
            using (var context = new DatabaseContext())
            {
                context.MyUsers.ForEach(x =>
                {
                    if (x.Role != "guest")
                    {
                        ServiceRibbon serviceRibbon = new ServiceRibbon();
                        bool medal1 = false;
                        bool medal2 = false;
                        bool medal3 = false;
                        bool medal4 = false;
                        bool medal5 = false;
                        context.ServiceRibbons.ToList().ForEach(sr =>
                        {
                            if (sr.Id == x.MedalsList)
                            {
                                serviceRibbon = sr;
                            }
                        });
                        context.MedalsCommentator.ToList().ForEach(mc =>
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
                    }
                });
            }
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PostForUser(long selectedId, long userId)
        {
            using (var context = new DatabaseContext())
            {
                MyUser user = new MyUser();
                context.MyUsers.ForEach(x =>
                {
                    if (x.Id == userId)
                    {
                        user = x;
                    }
                });
                user.UserId = selectedId;
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}