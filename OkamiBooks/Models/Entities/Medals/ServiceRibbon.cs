using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OkamiBooks.Models.Entities.Medals;

namespace OkamiBooks.Models.Entities
{
    public class ServiceRibbon : Entity
    {

       

        public string ApplicationUser { get; set; }
        public long User { get; set; }
        public long MedalWriter { get; set; }
        public long MedalCommentator { get; set; }
        public long MedalCritic { get; set; }
        public long MedalLiker { get; set; }
        public long MedalReader { get; set; }
    }
}