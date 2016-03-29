using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Like : Entity
    {
        public ApplicationUser User { get; set; }
        public Comment Comment { get; set; }
    }
}