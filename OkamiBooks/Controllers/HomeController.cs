using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OkamiBooks.Models;
using OkamiBooks.Models.Entities;
using WebGrease.Css.Extensions;

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
                context.Tags.Add(new Tags {Name = "first", Books = new List<long>()});
                context.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public JsonResult GetBestBooks()
        {
            var bestBooks = new List<ExportBook>();
            using (var context = new DatabaseContext())
            {
                context.Books.ForEach(book =>
                {
                    if (bestBooks.Count < 10)
                    {
                        bestBooks.Add(new ExportBook(book));
                    }
                    else
                    {
                        var isAddeble = false;
                        bestBooks.ForEach(bestBook => {
                                                          if (bestBook.Rating < book.Rating)
                                                          {
                                                              isAddeble = true;
                                                          }
                        });
                        if (isAddeble)
                        {
                            var lessBestBook = bestBooks[0];
                            bestBooks.ForEach(bestBook => {
                                if (bestBook.Rating < lessBestBook.Rating)
                                {
                                    lessBestBook = bestBook;
                                }
                            });
                            bestBooks.Remove(lessBestBook);
                            bestBooks.Add(new ExportBook(book));
                        }
                    }

                });
            }
            return Json(bestBooks, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetLastBooks()
        {
            var lastBooks = new List<ExportBook>();
            using (var context = new DatabaseContext())
            {
                context.Books.ForEach(book =>
                {
                    if (lastBooks.Count < 10)
                    {
                        lastBooks.Add(new ExportBook(book));
                    }
                    else
                    {
                        var isAddeble = false;
                        lastBooks.ForEach(lastBook => {
                            if (lastBook.LastChangeTime < book.LastChangeTime)
                            {
                                isAddeble = true;
                            }
                        });
                        if (isAddeble)
                        {
                            var lessLastBook = lastBooks[0];
                            lastBooks.ForEach(lastBook => {
                                if (lastBook.LastChangeTime < lessLastBook.LastChangeTime)
                                {
                                    lessLastBook = lastBook;
                                }
                            });
                            lastBooks.Remove(lessLastBook);
                            lastBooks.Add(new ExportBook(book));
                        }
                    }

                });
            }
            return Json(lastBooks, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCategories()
        {
            var categories = new List<Category>();

            using (var context = new DatabaseContext())
            {
                categories = context.Categories.ToList();
            }
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetTags()
        {
            var tags = new List<ExportTags>();
            int maxSize = 0;
            using (var context = new DatabaseContext())
            {
                context.Tags.ToList().ForEach(x =>
                {
                    if (x.Books?.Count > maxSize)
                    {
                        maxSize = x.Books.Count;
                    }
                });
                context.Tags.ToList().ForEach(x =>
                {
                    if (x.Books?.Count > 0)
                    {
                        tags.Add(new ExportTags {Word = x.Name, Size = x.Books.Count/maxSize});
                    }
                });
            }
            return Json(tags, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public JsonResult PostForTags(long selectedId, long userId)
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
                user.TagId = selectedId;
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostForCategories(long selectedId, long userId)
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
                user.CategoriId = selectedId;
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UserGetting(long userId, long accsessToken)
        {
            
            MyUser user = new MyUser();
            using (var context = new DatabaseContext())
            {
               
                
                if (userId > 0)
                {
                    context.MyUsers.ForEach(x =>
                    {
                        if (x.Id == userId)
                        {
                            if (accsessToken == x.AcsesToken)
                            {
                                accsessToken = x.AcsesToken = new Random().Next(1, 100000);
                            }
                            else
                            {
                                userId = user.Id = context.IdSaviors.ToList()[0].MaxUserId++;
                                user.Role = "guest";
                                accsessToken = user.AcsesToken = new Random().Next(1, 100000);
                                context.MyUsers.Add(user);
                                context.SaveChanges();
                            }
                        }
                    });
                    
                }
                else
                {
                    userId = user.Id = context.IdSaviors.ToList()[0].MaxUserId++;
                    user.Role = "guest";
                    accsessToken = user.AcsesToken = new Random().Next(1, 100000);
                    context.MyUsers.Add(user);
                    context.SaveChanges();
                }
            }
            var resolt = new List<long>();
            resolt.Add(userId);
            resolt.Add(accsessToken);
            return Json(resolt, JsonRequestBehavior.AllowGet);
        }
    }
}