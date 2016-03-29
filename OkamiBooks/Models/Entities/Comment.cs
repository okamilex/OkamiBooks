using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Comment : Entity
    {
        public ApplicationUser User { get; set; }
        public Book Book { get; set; }
        public string Text { get; set; }
        public List<Like> Likes { get; set; }

    }
}