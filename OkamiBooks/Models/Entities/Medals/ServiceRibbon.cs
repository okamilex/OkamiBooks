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
       
        public virtual ApplicationUser User { get; set; }
        public virtual MedalWriter MedalWriter { get; set; }
        public virtual MedalCommentator MedalCommentator { get; set; }
        public virtual MedalCritic MedalCritic { get; set; }
        public virtual MedalLiker MedalLiker { get; set; }
        public virtual MedalReader MedalReader { get; set; }
    }
}