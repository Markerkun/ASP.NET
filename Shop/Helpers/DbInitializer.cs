using Shop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Helpers
{
    internal static class DbInitializer
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            var categories = new List<Category>();

            string[] names =
            {
        "Ноутбуки",
        "Відеокарти",
        "Процесори",
        "Монітори",
        "Материнські плати",
        "Оперативна пам'ять",
        "SSD накопичувачі",
        "Блоки живлення",
        "Корпуси",
        "Периферія"
    };

            for (int i = 0; i < names.Length; i++)
            {
                categories.Add(new Category
                {
                    Id = i + 1,
                    Name = names[i],
                    Description = $"Категорія {names[i]}"
                });
            }

            modelBuilder.Entity<Category>().HasData(categories);
        }


        public static void SeedBrands(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "ASUS", Country = "Taiwan" },
                new Brand { Id = 2, Name = "MSI", Country = "Taiwan" },
                new Brand { Id = 3, Name = "Intel", Country = "USA" },
                new Brand { Id = 4, Name = "AMD", Country = "USA" },
                new Brand { Id = 5, Name = "Samsung", Country = "South Korea" }
            );
        }


        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            var products = new List<Product>();
            int productId = 1;
            var random = new Random();

            for (int categoryId = 1; categoryId <= 10; categoryId++)
            {
                for (int i = 1; i <= 20; i++)
                {
                    products.Add(new Product
                    {
                        Id = productId++,
                        Name = $"Product {categoryId}-{i}",
                        Price = random.Next(1000, 50000),
                        Stock = random.Next(1, 50),
                        CategoryId = categoryId,
                        BrandId = random.Next(1, 6), 
                        Description = $"Опис товару {categoryId}-{i}",
                        CreatedAt = DateTime.Now
                    });
                }
            }

            modelBuilder.Entity<Product>().HasData(products);
        }



    }



}
}