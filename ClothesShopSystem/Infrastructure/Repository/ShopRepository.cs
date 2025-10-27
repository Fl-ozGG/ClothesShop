using ClothesShopSystem.API.DTOs;
using ClothesShopSystem.Domain.Entities;
using ClothesShopSystem.Domain.Enums;
using ClothesShopSystem.Domain.Repositories;
using ClothesShopSystem.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ClothesShopSystem.Infrastructure.Repository;

public class ShopRepository(ShopDbContext context ) : IShopRepository
{
 

    //TODO: repository solo devuelve algo no es su responsabilidad la de validar nulls
    public async Task<Shop> Persist(Shop shop)
    {
        await context.AddAsync(shop);
        await context.SaveChangesAsync();
        return shop;
    }
    public async Task<bool> AddressDontExists(string shopAddress)
    {
        var shop = await context.Shops.FirstOrDefaultAsync(s => s.Adress == shopAddress);
        return shop == null;
    }
    public async Task<bool> ShopExists(Guid shopId)
    {
        var shop = await context.Shops.FirstOrDefaultAsync(s => s.Id == shopId);
        return shop != null;
    }

    public async Task<List<Shop>> GetShops()
    {
        var shops = await context.Shops.ToListAsync();
        return shops;
    }

    public async Task<Shop> GetShop(Guid shopId)
    {
        var shop = await context.Shops.FirstOrDefaultAsync(s => s.Id == shopId);
        if (shop == null) throw new Exception( "Shop not found");
        return shop;
    }

    public async Task<bool> Buy(Product product, int amount)
    {
        product.Stock -= amount;
        await context.SaveChangesAsync();
        return true;
    }
    
}