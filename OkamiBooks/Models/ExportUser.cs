using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models
{
    public class ExportUser
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public bool Medal1 { get; set; }
        public bool Medal2 { get; set; }
        public bool Medal3 { get; set; }
        public bool Medal4 { get; set; }
        public bool Medal5 { get; set; }
    }
}