using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class UserBookInfo : Entity
    {
        public ApplicationUser User { get; set; }
        public Book Book { get; set; }
        public int Rating { get; set; }
        public Chapter Chapter { get; set; }
        public int ChapterNumber { get; set; }
        public int Place { get; set; }
    }
}