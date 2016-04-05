using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Like : Entity
    {

        public string ApplicationUser { get; set; }
        public long Comment { get; set; }
    }
}