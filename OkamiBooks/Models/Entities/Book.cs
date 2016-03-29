using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Book : Entity
    {
        public ApplicationUser User { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public int RatedAmount { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Tags> Tags { get; set; }
        public DateTime LastChangeTime { get; set; }

    }
}