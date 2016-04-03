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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetUser(int userId)
        {
            var user = new ExportUser();
            long gettingUserId = 0;
            using (var context = new DatabaseContext())
            {
                context.MyUsers.ForEach(x =>
                {
                    if (x.Id == userId)
                    {
                        gettingUserId = x.UserId;
                    }

                });
                    context.MyUsers.ForEach(x =>
                {
                    if (x.Id == gettingUserId)
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
                        user = new ExportUser { Id = x.Id, Email = x.Email, Medal1 = medal1, Medal2 = medal2, Medal3 = medal3, Medal4 = medal4, Medal5 = medal5 };
                    }
                });
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetBooks(int userId)
        {
            var books = new List<ExportBook>();
            long gettingUserId = 0;
            using (var context = new DatabaseContext())
            {
                context.MyUsers.ForEach(x =>
                {
                    if (x.Id == userId)
                    {
                        gettingUserId = x.UserId;
                    }

                });
                context.MyUsers.ForEach(x =>
                {
                    if (x.Id == gettingUserId)
                    {
                        x.Books.ForEach(bookId =>
                        {
                            context.Books.ForEach(book =>
                            {
                                if (book.Id == bookId)
                                {
                                    books.Add(new ExportBook(book));
                                }
                            });
                        });
                    }
                });
            }
            return Json(books, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostForBook(long selectedId, long userId)
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
                user.BookId = selectedId;
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}