using ClothesShopSystem.Domain.Entities;
using ClothesShopSystem.Domain.Enums;
using ClothesShopSystem.Domain.Repositories;
using ClothesShopSystem.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ClothesShopSystem.Infrastructure.Repository;

public class UserRepository(ShopDbContext context) : IUserRepository
{
    
    public async Task<User> Persist(User user)
    {
        context.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UserDontExist(User userToCheck)
    {
        var userEmailFound = await context.Users.FirstOrDefaultAsync(u => u.Email == userToCheck.Email);
        if (userEmailFound == null)
        {
            return true;
        }
        return userEmailFound.UserType != userToCheck.UserType;
    }
    // hacer un solo metodo que reciba por parametro el  tipo a evaluar y el id TODO
    public async Task<bool> IsSupplier(Guid id)
    {
        var user = await context.Users.FirstOrDefaultAsync(e => e.Id == id);
        if (user == null) throw new Exception("User not found");
        return user.UserType == UserTypeEnum.Supplier;
    }
    public async Task<bool> IsDirective(Guid directiveId)
    {
        var user = await context.Users.FirstOrDefaultAsync(s => s.Id == directiveId);
        if (user == null) throw new Exception("Directive not found");
        return user.UserType == UserTypeEnum.Directive;
    }

    public async Task<bool> OwnsProduct(Guid userId, Guid productId)
    {
        var user = await GetUser(userId);
        var product = await context.Products.FirstOrDefaultAsync(e => e.Id == productId);
        if (product == null)
        {
            throw new Exception("Product not found");
        }
        return product.SupplierId == user.Id;

    }

    public async Task<User> GetUser(Guid userId)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        return user;
    }

    public async Task<List<User>> GetUsers()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<List<Product>> GetUserProducts(Guid id)
    {
        var products = await context.Products.ToListAsync();
        var productsFromUser = products.FindAll(el => el.SupplierId == id);
        return productsFromUser;
    }
}