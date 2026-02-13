using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Helpers;

namespace Shop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            builder.Entity<CategoryModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
                .IsUniqe();
            });
            builder.Entity<BrandModel>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(100);
           });
            builder.Entity<ProductModel>(entity =>
           {
               entity.HasKey(e => e.Id);
               entity.Property(e => e.Name)
               .IsRequired()
               .HasMaxLength(200);
               entity.Property(e => e.Price)
               .IsRequired();
               entity.HasOne(e => e.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(e => e.CategoryId);
                    .OnDelete(DeleteBehavior.Cascade);
               entity.HasOne(e => e.Brand)
                   .WithMany(b => b.Products)
                   .HasForeignKey(e => e.BrandId);
                    .OnDelete(DeleteBehavior.Cascade);
           });

            modelBuilder.SeedCategories();
            modelBuilder.SeedBrands();
            modelBuilder.SeedProduct();




        }
    




    }

}
