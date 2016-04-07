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
    public class ReadController : Controller
    {
        // GET: Read
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetText(string userName, long accsessToken)
        {
            string newText = "";
            long bookId = 0;
            long chapterId = 0;
            using (var context = new DatabaseContext())
            {
                context.SaveChanges();
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        bookId = x.BookId;
                    }
                });
                context.UserBookInfos.ForEach(x =>
                {
                    if ((x.ApplicationUser == userName) && (x.Book == bookId))
                    {
                        chapterId = x.Chapter;
                    }
                });
                if (chapterId != 0)
                {
                    context.Chapters.ForEach(x =>
                    {
                        if (x.Id == chapterId)
                        {
                            newText = x.Text;
                        }
                    });
                }
                else
                {
                    context.Books.ForEach(x =>
                    {
                        if (x.Id == bookId)
                        {
                            chapterId = x.GetChaptersList()[0];
                        }
                    });
                    if (chapterId != 0)
                    {
                        context.UserBookInfos.Add(new UserBookInfo
                        {
                            ApplicationUser = userName,
                            Book = bookId,
                            Chapter = chapterId
                        });
                        context.Chapters.ForEach(x =>
                        {
                            if (x.Id == chapterId)
                            {
                                newText = x.Text;
                            }
                        });
                    }
                }
                context.SaveChanges();
            }
            return Json(newText, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPrev(string userName, long accsessToken)
        {
            string newText = "";
            long bookId = 0;
            long chapterId = 0;
            long prevChapterId = 0;
            bool found = false;
            bool hasPrev = true;
            bool hasNext = true;
            using (var context = new DatabaseContext())
            {
                context.SaveChanges();
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        bookId = x.BookId;
                    }
                });
                context.UserBookInfos.ForEach(x =>
                {
                    if ((x.ApplicationUser == userName) && (x.Book == bookId))
                    {
                        chapterId = x.Chapter;
                    }
                });
                if (chapterId != 0)
                {
                    context.Books.ForEach(x =>
                    {
                        if (x.Id == bookId)
                        {
                            x.GetChaptersList().ForEach(c =>
                            {
                                if (c == chapterId)
                                {
                                    found = true;
                                }
                                if (!found)
                                {
                                    prevChapterId = c;
                                }
                            });
                        }
                    });
                    context.Books.ForEach(x =>
                    {
                        if (x.Id == bookId)
                        {
                            if (x.GetChaptersList().First() == prevChapterId)
                            {
                                hasPrev = false;
                            }
                            if (x.GetChaptersList().Last() == prevChapterId)
                            {
                                hasNext = false;
                            }
                        }
                    });
                    context.UserBookInfos.ForEach(x =>
                    {
                        if ((x.ApplicationUser == userName) && (x.Book == bookId))
                        {
                            x.Chapter = prevChapterId;
                        }
                    });
                    context.Chapters.ForEach(x =>
                    {
                        if (x.Id == prevChapterId)
                        {
                            newText = x.Text;
                        }
                    });
                }
                context.SaveChanges();
            }
            return Json(new { text = newText, prev = hasPrev, next = hasNext }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GetNext(string userName, long accsessToken)
        {
            string newText = "";
            long bookId = 0;
            long chapterId = 0;
            long nextChapterId = 0;
            bool found = false;
            bool hasNext = true;
            bool hasPrev = true;
            using (var context = new DatabaseContext())
            {
                context.SaveChanges();
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        bookId = x.BookId;
                    }
                });
                context.UserBookInfos.ForEach(x =>
                {
                    if ((x.ApplicationUser == userName) && (x.Book == bookId))
                    {
                        chapterId = x.Chapter;
                    }
                });
                if (chapterId != 0)
                {
                    context.Books.ForEach(x =>
                    {
                        if (x.Id == bookId)
                        {
                            x.GetChaptersList().ForEach(c =>
                            {
                                if (found)
                                {
                                    nextChapterId = c;
                                    found = false;
                                }
                                if (c == chapterId)
                                {
                                    found = true;
                                }
                            });
                        }
                    });
                    context.Books.ForEach(x =>
                    {
                        if (x.Id == bookId)
                        {
                            if (x.GetChaptersList().First() == nextChapterId)
                            {
                                hasPrev = false;
                            }
                            if (x.GetChaptersList().Last() == nextChapterId)
                            {
                                hasNext = false;
                            }
                        }
                    });
                    context.UserBookInfos.ForEach(x =>
                    {
                        if ((x.ApplicationUser == userName) && (x.Book == bookId))
                        {
                             x.Chapter = nextChapterId;
                        }
                    });
                    context.Chapters.ForEach(x =>
                    {
                        if (x.Id == nextChapterId)
                        {
                            newText = x.Text;
                        }
                    });
                }
                context.SaveChanges();
            }
           
            return Json(new { text = newText, prev = hasPrev, next = hasNext}, JsonRequestBehavior.AllowGet);
            
        }

        [HttpPost]
        public JsonResult ChaekNext(string userName, long accsessToken)
        {
            long bookId = 0;
            long chapterId = 0;
            bool hasNext = true;
            using (var context = new DatabaseContext())
            {
                
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        bookId = x.BookId;
                    }
                });
                context.UserBookInfos.ForEach(x =>
                {
                    if ((x.ApplicationUser == userName) && (x.Book == bookId))
                    {
                        chapterId = x.Chapter;
                    }
                });
                if (chapterId != 0)
                {
                    context.Books.ForEach(x =>
                    {
                        if (x.Id == bookId)
                        {
                            if (x.GetChaptersList().Last() == chapterId)
                            {
                                hasNext = false;
                            }
                        }
                    });
                }
                context.SaveChanges();
            }
            return Json(hasNext, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ChaekPrev(string userName, long accsessToken)
        {
            long bookId = 0;
            long chapterId = 0;
            bool hasPrev = true;
            using (var context = new DatabaseContext())
            {
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        bookId = x.BookId;
                    }
                });
                context.UserBookInfos.ForEach(x =>
                {
                    if ((x.ApplicationUser == userName) && (x.Book == bookId))
                    {
                        chapterId = x.Chapter;
                    }
                });
                if (chapterId != 0)
                {
                    context.Books.ForEach(x =>
                    {
                        if (x.Id == bookId)
                        {
                            if (x.GetChaptersList().First() == chapterId)
                            {
                                hasPrev = false;
                            }
                        }
                    });
                }
                context.SaveChanges();
            }
            return Json(hasPrev, JsonRequestBehavior.AllowGet);
        }

    }
}