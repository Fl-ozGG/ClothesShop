using ClothesShopSystem.Domain.Entities;

namespace ClothesShopSystem.Domain.Repositories;

public interface IUserRepository
{
    Task<User> Persist(User user);
    Task<bool> UserDontExist(User user);
    Task<bool> IsSupplier(Guid userId);
    Task<bool> IsDirective(Guid userId);
    Task<bool> OwnsProduct(Guid userId, Guid productId);
    Task<User> GetUser(Guid userId);
    Task<List<User>> GetUsers();
    Task<List<Product>> GetUserProducts(Guid id);
    
}
