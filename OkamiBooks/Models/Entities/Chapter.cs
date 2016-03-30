using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Chapter : Entity
    {
        public virtual Book Book { get; set; }
        public string Name { get; set; }
        public string BriefText { get; set; }
        public string Text { get; set; }
        public DateTime LastChangeTime { get; set; }
    }
}