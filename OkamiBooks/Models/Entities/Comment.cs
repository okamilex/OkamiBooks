using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Comment : Entity
    {

        public string ApplicationUser { get; set; }
        
        public long Book { get; set; }
        public string Text { get; set; }
        public string Likes { get; set; }
        public void LikesAdd(long newId)
        {
            if (Likes != "")
            {
                Likes = Likes + "," + newId;
            }
            else
            {
                Likes = newId.ToString();
            }
        }
        public List<long> GetLikesList()
        {
            return Likes != "" ? Likes.Split(',').Select(long.Parse).ToList() : new List<long>();
        }

    }
}