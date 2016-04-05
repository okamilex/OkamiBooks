using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OkamiBooks.Models.Entities;
using OkamiBooks.Models.Entities.Medals;

namespace OkamiBooks.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string MyRole { get; set; }
        public long MedalsList { get; set; }
        public long AcsesToken { get; set; }
        public string Books { get; set; }
        public string Comments { get; set; }
        public string Likes { get; set; }
        public string BookInfos { get; set; }

        public long BookId { get; set; }
        public long TagId { get; set; }
        public string UserNameToGet { get; set; }
        public long CategoriId { get; set; }
        public long ChapterId { get; set; }

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
        public List<long> GetCommentsList()
        {
            return Comments != "" ? Comments.Split(',').Select(long.Parse).ToList() : new List<long>();           
        }
        public void BooksAdd(long newId)
        {
            if (Books != "")
            {
                Books = Books + "," + newId;
            }
            else
            {
                Books = newId.ToString();
            }
        }
        public List<long> GetBooksList()
        {
            return Books != "" ? Books.Split(',').Select(long.Parse).ToList() : new List<long>();
            
        }
        public void BookInfosAdd(long newId)
        {
            if (BookInfos != "")
            {
                BookInfos = BookInfos + "," + newId;
            }
            else
            {
                BookInfos = newId.ToString();
            }
        }
        public List<long> GetBookInfosList()
        {
            return BookInfos != "" ? BookInfos.Split(',').Select(long.Parse).ToList() : new List<long>();
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }





    

 
}