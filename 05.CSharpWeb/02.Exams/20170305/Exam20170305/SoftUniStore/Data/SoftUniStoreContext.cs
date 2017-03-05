namespace SoftUniStore.Data
{
    using SoftUniStore.Models;
    using System.Data.Entity;

    public class SoftUniStoreContext : DbContext
    {
        public SoftUniStoreContext()
            : base("name=SoftUniStoreContext")
        {
        }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Game> Games { get; set; }
    }

}