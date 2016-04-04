using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Comment : Entity
    {

        public string ApplicationUser { get; set; }
        public long User { get; set; }
        public long Book { get; set; }
        public string Text { get; set; }
        public List<long> Likes { get; set; }

    }
}