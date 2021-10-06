using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDbContext: DbContext
    {
        public DbSet<BaseCategory> BaseCategory;
        public DbSet<Category> Categories;
        public DbSet<Product> Product;

        public AppDbContext(DbContextOptions settings)
            : base(settings)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x=>x.Id);
                entity.ToTable("Category");
                entity.HasOne(x=>x.BaseCategory);
            });

            modelBuilder.Entity<BaseCategory>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x=>x.Categories);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasIndex(x => x.Brand);
                entity.HasOne(x=>x.Category);
                entity.Property(x => x.Price).HasPrecision(7,2);
            });
        }

    }
}
