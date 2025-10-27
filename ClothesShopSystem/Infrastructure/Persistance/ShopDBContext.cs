using ClothesShopSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClothesShopSystem.Infrastructure.Persistance;

public class ShopDbContext : DbContext
{

    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options){}
    public DbSet<Shop> Shops { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=ClothesShopSystem.db");
    }

   
}