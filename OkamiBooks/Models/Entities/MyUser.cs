using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkamiBooks.Models.Entities
{
    public class MyUser : Entity
    {
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public long AcsesToken { get; set; }
        public string Role { get; set; }
        public long MedalsList { get; set; }
        public List<long> Books { get; set; }
        public List<long> Comments { get; set; }
        public List<long> Likes { get; set; }
        public List<long> BooksInfo { get; set; }
        

        public long BookId { get; set; }
        public long TagId { get; set; }
        public long UserId { get; set; }
        public long CategoriId { get; set; }
        public long ChapterId { get; set; }
    }
}