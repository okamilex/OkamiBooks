using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Book : Entity
    {
        public virtual ApplicationUser User { get; set; }
        public string Name { get; set; }
        public virtual Category Category{ get; set; }
        public double Rating { get; set; }
        public int RatedAmount { get; set; }
        public virtual List<Chapter> Chapters { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Tags> Tags { get; set; }
        public DateTime LastChangeTime { get; set; }
    }
}