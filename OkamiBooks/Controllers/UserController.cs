﻿using System;
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
        public JsonResult GetUser(string userName)
        {
            var user = new ExportUser();
            string gettingUserName = "";
            ServiceRibbon serviceRibbon = new ServiceRibbon();
            ApplicationUser applicationUser = new ApplicationUser();
            using (var context = new DatabaseContext())
            {
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        gettingUserName = x.UserNameToGet;
                    }

                });
                gettingUserName = "alex1196@mail.ru";
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == gettingUserName)
                    {
                        applicationUser = x;
                    }
                });
                    bool medal1 = false;
                        bool medal2 = false;
                        bool medal3 = false;
                        bool medal4 = false;
                        bool medal5 = false;
                        context.ServiceRibbons.ToList().ForEach(sr =>
                        {
                            if (sr.Id == applicationUser.MedalsList)
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
                        user = new ExportUser { Id = applicationUser.Id, Email = applicationUser.Email, Medal1 = true, Medal2 = medal2, Medal3 = medal3, Medal4 = medal4, Medal5 = medal5 };
                   
            }
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetProm(string userName, long accsessToken)
        {
            
            bool prom = false;
            using (var context = new DatabaseContext())
            {
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        if (x.AcsesToken == accsessToken)
                        {
                            accsessToken = x.AcsesToken = new Random().Next(1, 100000);
                            
                            if ((x.UserName == x.UserNameToGet) || (x.MyRole == "admin"))
                            {
                                prom = true;
                            }
                        }
                        if ((x.UserName == x.UserNameToGet) || (x.MyRole == "admin"))
                        {
                            prom = true;
                        }

                    }
                });
            }
            return Json(new {userName, accsessToken, prom}, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetBooks(string userName)
        {

            

            var books = new List<ExportBook>();
            string gettingUserName = "";
            using (var context = new DatabaseContext())
            {
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        gettingUserName = x.UserNameToGet;
                        
                    }

                });
                ApplicationUser applicationUser = new ApplicationUser();
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == gettingUserName)
                    {
                        applicationUser = x;
                    }
                });
                applicationUser.Books = new List<long>();
                applicationUser.Comments = new List<long>();
                applicationUser.Likes = new List<long>();
                applicationUser.BooksInfo = new List<long>();
                applicationUser.Books.ForEach(bookId =>
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
            return Json(books, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostForBook(long selectedId, string userName)
        {


            using (var context = new DatabaseContext())
            {
                MyUser user = new MyUser();
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
        public JsonResult NewBook(string userName, long accsessToken)
        {
            bool allOk = false;
            using (var context = new DatabaseContext())
            {
                ApplicationUser applicationUser = new ApplicationUser();
                
                bool finded = false;
                string neededName = "";
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        if (x.AcsesToken == accsessToken)
                        {
                            if (x.UserNameToGet == userName) 
                            {
                                allOk = true;
                                finded = true;
                                applicationUser = x;
                            }
                            if (x.MyRole == "admin")
                            {
                                neededName = x.UserNameToGet;
                                allOk = true;
                            }
                        }
                    }
                });
                if (!finded)
                {
                    context.ApplicationUsers.ForEach(x =>
                    {
                        if (x.UserName == neededName)
                        {
                                applicationUser = x;
                        }
                    });

                }
                if (allOk)
                {
                    long id = context.IdSaviors.ToList()[0].MaxBook++;
                    context.Books.Add(new Book { Id = id });
                    applicationUser.Books.Add(id);
                    applicationUser.BookId = id;
                }
                
            }
            bool success = allOk;
            return Json(success, JsonRequestBehavior.AllowGet);
        }
    }
}