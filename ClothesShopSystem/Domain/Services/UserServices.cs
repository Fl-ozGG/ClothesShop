using ClothesShopSystem.API.DTOs;
using ClothesShopSystem.Domain.Entities;
using ClothesShopSystem.Domain.Repositories;

namespace ClothesShopSystem.Domain.Services;

public class UserServices
{
    private readonly IUserRepository _userRepository;
    
    public UserServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<User> Create(CreateUserRequest request)
    {
        var user = new User(request.Name, request.Email, request.BornYear, request.Address, request.City,
            request.PhoneNumber, request.UserType);
        var userNotInDb = await _userRepository.UserDontExist(user);
        if (userNotInDb)
        {
            return await _userRepository.Persist(user);
        }
        else
        {
            throw new Exception("This email is already used by another user.");
        }
    }
    public async Task<List<User>> GetUsers()
    {
        var users = await _userRepository.GetUsers();
        if (!users.Any()) throw new Exception("No users found.");
        return users.ToList();
    }

    public async Task<List<Product>> GetUserProducts(Guid id)
    {
        
        var userProducts = await _userRepository.GetUserProducts(id);
        if (!userProducts.Any()) throw new Exception("No users found.");
        return userProducts.ToList();
    }
    
}