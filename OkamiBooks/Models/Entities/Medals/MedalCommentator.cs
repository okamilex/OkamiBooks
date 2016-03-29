using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities.Medals
{
    public class MedalCommentator : Entity
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int Progress { get; set; }
        public bool IsReceived
        {
            get
            {
                if (Progress == 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set { IsReceived = value; }
        }
    }
}