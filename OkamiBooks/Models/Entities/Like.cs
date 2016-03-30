using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Like : Entity
    {
        public virtual ApplicationUser User { get; set; }
        public virtual Comment Comment { get; set; }
    }
}