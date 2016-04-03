using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Book : Entity
    {
        //public virtual ApplicationUser User { get; set; }

        public long User { get; set; }
        public string Name { get; set; }
        public string Category{ get; set; }
        public double Rating { get; set; }
        public int RatedAmount { get; set; }
        public List<long> Chapters { get; set; }
        public List<long> Comments { get; set; }
        public List<string> Tags { get; set; }
        public DateTime LastChangeTime { get; set; }
    }
}