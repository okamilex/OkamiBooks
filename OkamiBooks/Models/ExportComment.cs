using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OkamiBooks.Models.Entities;

namespace OkamiBooks.Models
{
    public class ExportComment
    {
        public string UserName { get; set; }
        public string CommentText { get; set; }
        public long LikeAmount { get; set; }
        public bool IsLiked { get; set; }

        public ExportComment(Comment comment, bool isLiked)
        {
            UserName = comment.ApplicationUser;
            CommentText = comment.Text;
            LikeAmount = comment.GetLikesList().Count;
            IsLiked = isLiked;
        }
    }
}