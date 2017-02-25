namespace SharpStore.Data
{
    using System;
    using System.Data.Entity;
    using SharpStore.Models;
    using System.Linq;

    public class SharpStoreContext : DbContext
    {
        public SharpStoreContext()
            : base("name=SharpStoreContext")
        {
        }

        public DbSet<Knife> Knives { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}