using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.Data.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class PfmDbContext : IdentityDbContext<ApplicationUser>
    {
        public PfmDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MoneyStream> MoneyStreams { get; set; }

        public static PfmDbContext Create()
        {
            return new PfmDbContext();
        }

        public new void Dispose()
        {
            base.SaveChanges();
            base.Dispose();
        }
    }
}