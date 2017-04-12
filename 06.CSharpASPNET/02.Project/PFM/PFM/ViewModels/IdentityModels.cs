using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PFM.Models;

namespace PFM.ViewModels
{
    public class PFMDbContext : IdentityDbContext<ApplicationUser>
    {
        public PFMDbContext()
            : base("PFMContext", throwIfV1Schema: false)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MoneyStream> MoneyStreams { get; set; }

        public static PFMDbContext Create()
        {
            return new PFMDbContext();
        }

    }
}