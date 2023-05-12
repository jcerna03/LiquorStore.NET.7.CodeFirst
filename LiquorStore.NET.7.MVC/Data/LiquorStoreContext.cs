using LiquorStore.NET._7.MVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LiquorStore.NET._7.MVC.Data
{
    public class LiquorStoreContext : DbContext
    {
        public LiquorStoreContext(DbContextOptions<LiquorStoreContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Liquor> Liquors { get; set; }
        public DbSet<LiquorCoctel> LiquorCoctels { get; set; }
        public DbSet<Coctel> Coctels { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Preparation> Preparations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //This allows us to change the default behavior of table naming, to prevent them from being created with a plural name.
            modelBuilder.Entity<Brand>().ToTable(nameof(Brand));
            modelBuilder.Entity<Category>().ToTable(nameof(Category));
            modelBuilder.Entity<Liquor>().ToTable(nameof(Liquor));
            modelBuilder.Entity<LiquorCoctel>().ToTable(nameof(LiquorCoctel));
            modelBuilder.Entity<Coctel>().ToTable(nameof(Coctel));
            modelBuilder.Entity<Ingredient>().ToTable(nameof(Ingredient));
            modelBuilder.Entity<Preparation>().ToTable(nameof(Preparation));
        }
    }
}
