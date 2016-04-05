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
                if (context.Categories.ToList().Count < 1)
                {
                    context.Categories.Add(new Category { Name = "Sci-fi" });
                    context.Categories.Add(new Category { Name = "FaryTail" });
                    context.IdSaviors.Add(new IdSavior { MaxChapter = 1, MaxGuest = 1, MaxBook = 1, MaxComment = 1, MaxLike = 1, MaxMedalCommentator = 1, MaxMedalCritic = 1, MaxMedalLiker = 1, MaxMedalReader = 1, MaxMedalWriter = 1, MaxServiceRibbon = 1, MaxUserBookInfo = 1 });

                }


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
            long maxSize = 0;
            using (var context = new DatabaseContext())
            {
                context.Tags.ToList().ForEach(x =>
                {
                    if (x.BookCount > maxSize)
                    {
                        maxSize = x.BookCount;
                    }
                });
                context.Tags.ToList().ForEach(x =>
                {
                    if (x.BookCount > 0)
                    {
                        tags.Add(new ExportTags {Word = x.Name, Size = (int)(x.BookCount/maxSize*10)});
                    }
                });
            }
            return Json(tags, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostForBook(long selectedId, string userName)
        {
            

            using (var context = new DatabaseContext())
            {
                
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        x.BookId = selectedId;
                    }
                });
                
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostForTags(long selectedId, string userName)
        {
            using (var context = new DatabaseContext())
            {
                
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        x.TagId = selectedId;
                    }
                });
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostForCategories(long selectedId, string userName)
        {
            using (var context = new DatabaseContext())
            {
                
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        x.CategoriId = selectedId;
                    }
                });
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult UserGetting(string userName, long accsessToken)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            using (var context = new DatabaseContext())
            {
               
                
                if (userName != "-1")
                {
                    context.ApplicationUsers.ForEach(x =>
                    {
                        if (x.UserName == userName)
                        {
                            if (accsessToken == x.AcsesToken)
                            {
                                accsessToken = x.AcsesToken = new Random().Next(1, 100000);
                            }
                            else
                            {
                                context.ApplicationUsers.Add(applicationUser);
                                
                                applicationUser.UserName = applicationUser.Email = userName = "guest" + context.IdSaviors.ToList()[0].MaxGuest++;

                                applicationUser.MyRole = "guest";
                                accsessToken = applicationUser.AcsesToken = new Random().Next(1, 100000);
                                context.SaveChanges();
                            }
                        }
                    });
                    
                }
                else
                {
                    context.ApplicationUsers.Add(applicationUser);
                    applicationUser.UserName = applicationUser.Email = userName = "guest" + context.IdSaviors.ToList()[0].MaxGuest++;

                    applicationUser.MyRole = "guest";
                    accsessToken = applicationUser.AcsesToken = new Random().Next(1, 100000);
                    context.SaveChanges();
                }
            }
            var resolt = new List<string>();
            resolt.Add(userName);
            resolt.Add(accsessToken.ToString());
            return Json(resolt, JsonRequestBehavior.AllowGet);
        }
    }
}