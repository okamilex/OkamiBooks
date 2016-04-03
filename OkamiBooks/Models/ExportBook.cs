using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OkamiBooks.Models.Entities;

namespace OkamiBooks.Models
{
    public class ExportBook
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Rating { get; set; }
        public int CommentCount { get; set; }
        public DateTime LastChangeTime { get; set; }

        public ExportBook(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Category = book.Category;
            Rating = book.Rating;
            CommentCount = book.Comments.Count;
            LastChangeTime = book.LastChangeTime;
        }
    }
}