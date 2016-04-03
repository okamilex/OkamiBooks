using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class UserBookInfo : Entity
    {
        //public virtual ApplicationUser User { get; set; }

        public long User { get; set; }
        public long Book { get; set; }
        public int Rating { get; set; }
        public long Chapter { get; set; }
        public int Place { get; set; }
    }
}