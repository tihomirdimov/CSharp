using SharpStore.Models;

namespace SharpStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpStore.Data.SharpStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SharpStore.Data.SharpStoreContext context)
        {
            context.Knives.AddOrUpdate(knife=>knife.Name, new Knife[]
            {
                new Knife()
                {
                    Name = "Knife 1",
                    Price = 100,
                    ImageUrl = "http://new.uniquejapan.com/wp-content/uploads/2010/05/oyama_chefs_knife.jpg"
                },
                new Knife()
                {
                    Name = "Knife 2 (set)",
                    Price = 130,
                    ImageUrl = "https://i.kinja-img.com/gawker-media/image/upload/s--oZniiJHH--/c_scale,fl_progressive,q_80,w_800/190rzax043q95jpg.jpg"
                },
                new Knife()
                {
                    Name = "Knife 3",
                    Price = 90,
                    ImageUrl = "http://www.kitchenstuffilove.com/wp-content/uploads/chefs-knife.jpg"
                },
            });
        }
    }
}
