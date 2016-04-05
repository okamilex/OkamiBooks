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
    public class EditController : Controller
    {
        // GET: Edit
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetChap(string userName, long accsessToken)
        {
            var chapters = new List<Chapter>();
            long bookId = 0;
            using (var context = new DatabaseContext())
            {
                context.ApplicationUsers.ForEach(x =>
                {
                    if (x.UserName == userName)
                    {
                        bookId = x.BookId;

                    }
                });
                var thisBook = new Book();
                context.Books.ForEach(x =>
                {
                    if (x.Id == bookId)
                    {
                        thisBook = x;
                    }
                });
                thisBook.GetChaptersList().ForEach(x =>
                {
                    context.Chapters.ForEach(c =>
                    {
                        if (c.Id == x)
                        {
                            chapters.Add(c);
                        }
                    });
                });
            }
            return Json(chapters, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult AddChapter(string userName, long accsessToken, string chapterName)
        {
            var chapters = new List<Chapter>();
            long bookId = 0;
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
                var thisBook = new Book();
                context.Books.ForEach(x =>
                {
                    if (x.Id == bookId)
                    {
                        thisBook = x;
                    }
                });

                context.SaveChanges();
                var id = context.IdSaviors.ToList()[0].MaxChapter++;
                context.SaveChanges();
                context.Chapters.Add(new Chapter { Name = chapterName, LastChangeTime = DateTime.Now, Book = bookId });



                thisBook.ChaptersAdd(id);

                context.SaveChanges();
                thisBook.GetChaptersList().ForEach(x =>
                {
                    context.Chapters.ForEach(c =>
                    {
                        if (c.Id == x)
                        {
                            chapters.Add(c);
                        }
                    });
                });

            }
            return Json(chapters, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostName(string userName, long accsessToken, string bookName)
        {
            long bookId = 0;
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
                context.Books.ForEach(x =>
                {
                    if (x.Id == bookId)
                    {
                        x.Name = bookName;
                    }
                });
                context.SaveChanges();
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetName(string userName, long accsessToken)
        {
            long bookId = 0;
            string bookName = "";
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
                context.Books.ForEach(x =>
                {
                    if (x.Id == bookId)
                    {
                        bookName = x.Name;
                    }
                });
                context.SaveChanges();
            }
            return Json(bookName, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetCategory(string userName, long accsessToken)
        {
            string bookCategory = "";
            long bookId = 0;
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
                context.Books.ForEach(x =>
                {
                    if (x.Id == bookId)
                    {
                         bookCategory = x.Category;
                    }
                });
                context.SaveChanges();
            }
            return Json(bookCategory, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostCategory(string userName, long accsessToken, string bookCategory)
        {
            long bookId = 0;
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
                context.Books.ForEach(x =>
                {
                    if (x.Id == bookId)
                    {
                        x.Category = bookCategory;
                    }
                });
                context.SaveChanges();
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult PostText(string userName, long accsessToken, long chapterId, string text)
        {
            using (var context = new DatabaseContext())
            {
                context.SaveChanges();
                context.Chapters.ForEach(x =>
                {
                    if (x.Id == chapterId)
                    {
                        x.Text = text;
                    }
                });
                context.SaveChanges();
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetText(string userName, long accsessToken, long chapterId)
        {
            string newText = "";
            using (var context = new DatabaseContext())
            {
                context.SaveChanges();
                context.Chapters.ForEach(x =>
                {
                    if (x.Id == chapterId)
                    {
                        newText = x.Text;
                    }
                });
                context.SaveChanges();
            }
            return Json(newText, JsonRequestBehavior.AllowGet);
        }

    }
}