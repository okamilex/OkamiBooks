using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Comment : Entity
    {
        public virtual ApplicationUser User { get; set; }
        public virtual Book Book { get; set; }
        public string Text { get; set; }
        public virtual List<Like> Likes { get; set; }

    }
}