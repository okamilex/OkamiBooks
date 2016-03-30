using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace OkamiBooks.Models.Entities
{
    public class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}