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
            
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
            new Category { Name = "Ноутбуки", Description = "Портативні комп'ютери" },
            new Category { Name = "Відеокарти", Description = "GPU для ПК" },
            new Category { Name = "Процесори", Description = "CPU для комп'ютерів" },
            new Category { Name = "Монітори", Description = "Екрани та дисплеї" }
            });
        }

        public static void SeedBrands(this ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
            new Brand { Name = "ASUS", Country = "Taiwan" },
            new Brand { Name = "MSI", Country = "Taiwan" },
            new Brand { Name = "Intel", Country = "USA" },
            new Brand { Name = "AMD", Country = "USA" },
            new Brand { Name = "Samsung", Country = "South Korea" }
            });
        }
        
        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product
            {
                Name = "ASUS ROG Strix G15",
                Price = 45000,
                Stock = 10,
                CategoryId = categories.First(c => c.Name == "Ноутбуки").Id,
                BrandId = brands.First(b => b.Name == "ASUS").Id,
                Description = "Ігровий ноутбук 16GB RAM, RTX 4060"
            },
            new Product
            {
                Name = "MSI GeForce RTX 4070",
                Price = 28000,
                Stock = 5,
                CategoryId = categories.First(c => c.Name == "Відеокарти").Id,
                BrandId = brands.First(b => b.Name == "MSI").Id,
                Description = "Відеокарта 12GB GDDR6X"
            },
            new Product
            {
                Name = "Intel Core i7-13700K",
                Price = 17000,
                Stock = 7,
                CategoryId = categories.First(c => c.Name == "Процесори").Id,
                BrandId = brands.First(b => b.Name == "Intel").Id,
                Description = "16 ядерний процесор"
            }

            });


        }
        
        
        
    }
}