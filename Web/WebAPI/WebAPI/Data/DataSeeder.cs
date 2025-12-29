using WebAPI.Data;
using WebAPI.Models;
using System.Linq;
using System.Collections.Generic;

namespace WebAPI.Data
{
    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            // If categories already exist, do nothing
            if (context.Categories.Any()) return;

            var categories = new List<Category>
            {
                new Category { Name = "Electronics" },
                new Category { Name = "Books" },
                new Category { Name = "Clothing" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            // Add sample products
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 999.99m, CategoryId = categories[0].Id, ImageUrl = "laptop.jpg" },
                new Product { Name = "T-Shirt", Price = 19.99m, CategoryId = categories[2].Id, ImageUrl = "shirt.jpg" }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}