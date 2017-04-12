namespace Shop.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.ShopContext";
        }

        protected override void Seed(ShopContext context)
        {
            context.Addresses.AddOrUpdate(
                a => a.Location,
                new Address { Location = "Pirin 16 left rock" },
                new Address { Location = "Musala 1337 second floor" },
                new Address { Location = "Balkan 123" });

            var cheese = new Category { Name = "Cheese" };

            var products = new List<Product>()
            {
                new Product { Name = "Mozzarella", Price = 7.50m },
                new Product { Name = "Brie", Price = 12.20m },
                new Product { Name = "Brie De Meaux", Price = 12.20m }
            };

            products.ForEach(p => cheese.Products.Add(p));

            context.Categories.AddOrUpdate(c => c.Name, cheese);
        }
    }
}
