using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PFMContext : DbContext
    {

        public PFMContext()
            : base("PFMContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<MoneyStreamCategory> Categories { get; set; }
        public DbSet<MoneyStream> MoneyStreams { get; set; }
    }
}