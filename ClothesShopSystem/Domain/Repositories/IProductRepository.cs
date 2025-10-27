using ClothesShopSystem.API.DTOs;
using ClothesShopSystem.Domain.Entities;

namespace ClothesShopSystem.Domain.Repositories;

public interface IProductRepository
{
    Task<Product> Persist(Product product);
    Task<bool> AddProduct(Product product);
    Task<Product> GetProduct(Guid id);
    Task<List<Product>> GetProducts();
    Task<bool> AddProduct(Product product,Guid shopId);
    
}