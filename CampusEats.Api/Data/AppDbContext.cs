using CampusEats.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CampusEats.Api.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MenuItem> MenuItems => Set<MenuItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>(e =>
        {
            e.Property(m => m.Name).HasMaxLength(100).IsRequired();
            e.Property(m => m.Category).HasMaxLength(50);
            e.Property(m => m.Price).HasPrecision(10, 2);
        });

        // Seed data so the deployed API returns a real menu straight after migrations.
        modelBuilder.Entity<MenuItem>().HasData(
            new MenuItem { Id = 1, Name = "Chicken Kottu", Description = "Chopped roti stir-fried with chicken, egg and vegetables", Category = "Mains", Price = 850m },
            new MenuItem { Id = 2, Name = "Vegetable Fried Rice", Description = "Wok-fried basmati rice with seasonal vegetables", Category = "Mains", Price = 650m },
            new MenuItem { Id = 3, Name = "Fish Bun", Description = "Soft bun filled with spicy fish and potato", Category = "Snacks", Price = 120m },
            new MenuItem { Id = 4, Name = "Egg Roll", Description = "Crumbed pancake roll with egg and vegetable filling", Category = "Snacks", Price = 150m },
            new MenuItem { Id = 5, Name = "Iced Milo", Description = "Chilled chocolate malt drink", Category = "Drinks", Price = 250m },
            new MenuItem { Id = 6, Name = "Faluda", Description = "Rose syrup, milk, basil seeds and ice cream", Category = "Drinks", Price = 350m });
    }
}
