using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PersonalFinanceManager.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Category> Categoris { get; set; }
        public virtual ICollection<MoneyStream> MoneyStreams { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}