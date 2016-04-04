using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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
        public List<long> Books { get; set; }
        public List<long> Comments { get; set; }
        public List<long> Likes { get; set; }
        public List<long> BooksInfo { get; set; }


        public long BookId { get; set; }
        public long TagId { get; set; }
        public string UserNameToGet { get; set; }
        public long CategoriId { get; set; }
        public long ChapterId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }





    

 
}