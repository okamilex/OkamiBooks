using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class IdSavior : Entity
    {
        public int BookId { get; set; }
        public int TagId { get; set; }
        public int UserId { get; set; }
        public int CategoriId { get; set; }
        public int ChapterId { get; set; }
       
    }
}