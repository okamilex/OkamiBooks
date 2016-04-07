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
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Get(string userName, long accsessToken)
        {
            bool isRated = true;
            bool isUser = false;
            long bookId = 0;
            Book book = new Book();
            int raiting = -1;
            int myRaiting = -1;
            List<ExportComment> comments = new List<ExportComment>();
            using (var context = new DatabaseContext())
            {
                context.SaveChanges();
                context.ApplicationUsers.Where(x => x.UserName == userName).ForEach(x =>
                {
                    bookId = x.BookId;
                    if (x.MyRole != "guest")
                        isUser = true;
                });
                context.Books.Where(x => x.Id == bookId).ForEach(x => book = x);
                book.GetCommentsList().ForEach(x => context.Comments.Where(c => c.Id == x).ForEach(c => 
                {
                    bool isLiked = false;
                    context.Likes.Where(l => ((l.ApplicationUser == userName) && (l.Comment == c.Id))).ForEach(l => isLiked = true);
                    comments.Add(new ExportComment(c, isLiked));
                }));
                raiting = (int)book.Rating;
                UserBookInfo userBookInfo = null;
                context.UserBookInfos.ForEach(i =>
                {
                    if ((i.ApplicationUser == userName) && (i.Book == bookId))
                    {
                        userBookInfo = i;
                    }
                });
                if (userBookInfo == null)
                {
                    context.UserBookInfos.Add(new UserBookInfo {ApplicationUser = userName, Book = bookId, Rating = -1});
                }
                myRaiting = userBookInfo.Rating;
                if (myRaiting == -1)
                {
                    isRated = false;
                }
                context.SaveChanges();
            }

            return Json(new { comments = comments, raiting = raiting, myRaiting = myRaiting, isUser = isUser, isRated = isRated}, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Add(string userName, long accsessToken)
        {
            bool isRated = true;
            bool isUser = false;
            long bookId = 0;
            Book book = new Book();
            int raiting = -1;
            int myRaiting = -1;
            List<ExportComment> comments = new List<ExportComment>();
            using (var context = new DatabaseContext())
            {
                context.SaveChanges();
                context.ApplicationUsers.Where(x => x.UserName == userName).ForEach(x =>
                {
                    bookId = x.BookId;
                    if (x.MyRole != "guest")
                        isUser = true;
                });
                context.Books.Where(x => x.Id == bookId).ForEach(x => book = x);
                book.GetCommentsList().ForEach(x => context.Comments.Where(c => c.Id == x).ForEach(c =>
                {
                    bool isLiked = false;
                    context.Likes.Where(l => ((l.ApplicationUser == userName) && (l.Comment == c.Id))).ForEach(l => isLiked = true);
                    comments.Add(new ExportComment(c, isLiked));
                }));
                raiting = (int)book.Rating;
                UserBookInfo userBookInfo = null;
                context.UserBookInfos.ForEach(i =>
                {
                    if ((i.ApplicationUser == userName) && (i.Book == bookId))
                    {
                        userBookInfo = i;
                    }
                });
                if (userBookInfo == null)
                {
                    context.UserBookInfos.Add(new UserBookInfo { ApplicationUser = userName, Book = bookId, Rating = -1 });
                }
                myRaiting = userBookInfo.Rating;
                if (myRaiting == -1)
                {
                    isRated = false;
                }
                context.SaveChanges();
            }

            return Json(new { comments = comments, raiting = raiting, myRaiting = myRaiting, isUser = isUser, isRated = isRated }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Like(string userName, long accsessToken)
        {
            bool isRated = true;
            bool isUser = false;
            long bookId = 0;
            Book book = new Book();
            int raiting = -1;
            int myRaiting = -1;
            List<ExportComment> comments = new List<ExportComment>();
            using (var context = new DatabaseContext())
            {
                context.SaveChanges();
                context.ApplicationUsers.Where(x => x.UserName == userName).ForEach(x =>
                {
                    bookId = x.BookId;
                    if (x.MyRole != "guest")
                        isUser = true;
                });
                context.Books.Where(x => x.Id == bookId).ForEach(x => book = x);
                book.GetCommentsList().ForEach(x => context.Comments.Where(c => c.Id == x).ForEach(c =>
                {
                    bool isLiked = false;
                    context.Likes.Where(l => ((l.ApplicationUser == userName) && (l.Comment == c.Id))).ForEach(l => isLiked = true);
                    comments.Add(new ExportComment(c, isLiked));
                }));
                raiting = (int)book.Rating;
                UserBookInfo userBookInfo = null;
                context.UserBookInfos.ForEach(i =>
                {
                    if ((i.ApplicationUser == userName) && (i.Book == bookId))
                    {
                        userBookInfo = i;
                    }
                });
                if (userBookInfo == null)
                {
                    context.UserBookInfos.Add(new UserBookInfo { ApplicationUser = userName, Book = bookId, Rating = -1 });
                }
                myRaiting = userBookInfo.Rating;
                if (myRaiting == -1)
                {
                    isRated = false;
                }
                context.SaveChanges();
            }

            return Json(new { comments = comments, raiting = raiting, myRaiting = myRaiting, isUser = isUser, isRated = isRated }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Rate(string userName, long accsessToken)
        {
            bool isRated = true;
            bool isUser = false;
            long bookId = 0;
            Book book = new Book();
            int raiting = -1;
            int myRaiting = -1;
            List<ExportComment> comments = new List<ExportComment>();
            using (var context = new DatabaseContext())
            {
                context.SaveChanges();
                context.ApplicationUsers.Where(x => x.UserName == userName).ForEach(x =>
                {
                    bookId = x.BookId;
                    if (x.MyRole != "guest")
                        isUser = true;
                });
                context.Books.Where(x => x.Id == bookId).ForEach(x => book = x);
                book.GetCommentsList().ForEach(x => context.Comments.Where(c => c.Id == x).ForEach(c =>
                {
                    bool isLiked = false;
                    context.Likes.Where(l => ((l.ApplicationUser == userName) && (l.Comment == c.Id))).ForEach(l => isLiked = true);
                    comments.Add(new ExportComment(c, isLiked));
                }));
                raiting = (int)book.Rating;
                UserBookInfo userBookInfo = null;
                context.UserBookInfos.ForEach(i =>
                {
                    if ((i.ApplicationUser == userName) && (i.Book == bookId))
                    {
                        userBookInfo = i;
                    }
                });
                if (userBookInfo == null)
                {
                    context.UserBookInfos.Add(new UserBookInfo { ApplicationUser = userName, Book = bookId, Rating = -1 });
                }
                myRaiting = userBookInfo.Rating;
                if (myRaiting == -1)
                {
                    isRated = false;
                }
                context.SaveChanges();
            }

            return Json(new { comments = comments, raiting = raiting, myRaiting = myRaiting, isUser = isUser, isRated = isRated }, JsonRequestBehavior.AllowGet);

        }

    }
}