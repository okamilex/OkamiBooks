using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class Book : Entity
    {
        public string ApplicationUser { get; set; }

        
        public string Name { get; set; }
        public string Category{ get; set; }
        public double Rating { get; set; }
        public int RatedAmount { get; set; }
        public string Chapters { get; set; }
        public string Comments { get; set; }
        public string Tags{ get; set; }
        public DateTime LastChangeTime { get; set; }

        public void ChaptersAdd(long newId)
        {
            if (Chapters != "")
            {
                Chapters = Chapters + "," + newId;
            }
            else
            {
                Chapters = newId.ToString();
            }
        }
        public void CommentsAdd(long newId)
        {
            if (Comments != "")
            {
                Comments = Comments + "," + newId;
            }
            else
            {
                Comments = newId.ToString();
            }
        }
        public void TagsAdd(long newId)
        {
            if (Tags != "")
            {
                Tags = Tags + "," + newId;
            }
            else
            {
                Tags = newId.ToString();
            }
            
        }
        public List<long> GetChaptersList()
        {
            return Chapters != "" ? Chapters.Split(',').Select(long.Parse).ToList() : new List<long>();
        }
        public List<long> GetCommentsList()
        {
            return Comments != "" ? Comments.Split(',').Select(long.Parse).ToList() : new List<long>();
        }
        public List<long> GetTagsList()
        {
            return Tags != "" ? Tags.Split(',').Select(long.Parse).ToList() : new List<long>();
        }
    }
}