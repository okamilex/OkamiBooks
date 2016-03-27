using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Role: Entity
    {
        public string Name { get; set; }
        public bool CanAddBooks { get; set; }
        public bool CanRubCaravans { get; set; } 
    }
}