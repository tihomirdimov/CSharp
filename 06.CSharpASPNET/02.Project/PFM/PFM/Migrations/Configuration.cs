using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PFM.Data;
using PFM.Models;
using PFM.ViewModels;

namespace PFM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PFMDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PFMDbContext context)
        {

            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);

            }
            if (!context.Roles.Any(role => role.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("User");
                manager.Create(role);
            }
        }
    }
}
