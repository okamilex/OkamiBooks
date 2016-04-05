using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class IdSavior : Entity
    {
        public string MaxUserId { get; set; }
        public long MaxGuest { get; set; }
        public long MaxServiceRibbon { get; set; }
        public long MaxMedalWriter { get; set; }
        public long MaxMedalCommentator { get; set; }
        public long MaxMedalCritic { get; set; }
        public long MaxMedalLiker { get; set; }
        public long MaxMedalReader { get; set; }
        public long MaxBook { get; set; }
        public long MaxChapter { get; set; }
        public long MaxComment { get; set; }
        public long MaxLike { get; set; }
        public long MaxUserBookInfo{ get; set; }

    }
}