using ClothesShopSystem.API.DTOs;
using ClothesShopSystem.Domain.Services;
using Microsoft.AspNetCore.Mvc;


namespace ClothesShopSystem.API.Controllers;

public class UserController: ControllerBase
{
    private UserServices _userServices;

    public UserController(UserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpPost("create_user")]
    public async Task<ActionResult> CreateUser([FromBody]CreateUserRequest request)
    {
        var user = await _userServices.Create(request);
        return Ok(user);
    }

    [HttpGet("get_users")]
    public async Task<ActionResult> GetUsers()
    {
        var users = await _userServices.GetUsers();
        return Ok(users);
    }

    [HttpGet("users/{userId}/products")]
    public async Task<ActionResult> GetUserProducts(Guid userId)
    {
        var userProducts = await _userServices.GetUserProducts(userId);
        return Ok(userProducts);
    }
    
}