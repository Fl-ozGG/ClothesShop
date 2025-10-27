using ClothesShopSystem.Domain.Entities;
using ClothesShopSystem.Domain.Enums;
using ClothesShopSystem.Domain.Repositories;
using ClothesShopSystem.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ClothesShopSystem.Infrastructure.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ShopDbContext _context;

    public ProductRepository(ShopDbContext context)
    {
        _context = context;
    }
    public async Task<Product> Persist(Product product)
    {
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    
    public async Task<bool> AddProduct(Product product)
    {
        await _context.AddAsync(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Product> GetProduct(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(e => e.Id == id);
        if (product == null) throw new Exception("Product not found");
        return product;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<bool> AddProduct(Product product, Guid shopId)
    { 
        var existing = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
        
        if (existing == null) throw new ArgumentException("Product not found");
        
        existing.ShopId = shopId;
        await _context.SaveChangesAsync();
        return true;
    }

   
}