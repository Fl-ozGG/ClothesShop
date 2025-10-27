using ClothesShopSystem.API.DTOs;
using ClothesShopSystem.Domain.Entities;

namespace ClothesShopSystem.Domain.Repositories;

public interface IShopRepository
{
    Task<Shop> Persist(Shop shop);
    Task<bool> AddressDontExists(string shopAddress);
    Task<bool> ShopExists(Guid shopId);
    Task<List<Shop>> GetShops();
    Task<bool> Buy(Product product,int amount);
}