using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OkamiBooks.Models.Entities.Medals;

namespace OkamiBooks.Models.Entities
{
    public class ServiceRibbon : Entity
    {
        // TO-DO:  ПОЛЬЗОВАТЕЛЬ
        public ApplicationUser User { get; set; }
        public MedalWriter MedalWriter { get; set; }
        public MedalCommentator MedalCommentator { get; set; }
        public MedalCritic MedalCritic { get; set; }
        public MedalLiker MedalLiker { get; set; }
        public MedalReader MedalReader { get; set; }
    }
}