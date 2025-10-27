using ClothesShopSystem.API.DTOs;
using ClothesShopSystem.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopSystem.API.Controllers;


[ApiController]
[Route("api/[controller]")]

public class ShopController:ControllerBase
{   
    private ShopServices _shopServices;
    public ShopController(ShopServices shopServices)
    {
        _shopServices = shopServices;
    }
    
    [HttpPost("create_shop")]
    public async Task<ActionResult> CreateShop([FromBody] CreateShopRequest request)
    {
        var shop = await _shopServices.Create(request);
        return Ok(shop);
    }

    [HttpGet("get_shops")]
    public async Task<ActionResult> GetShops()
    {
        var shops = await _shopServices.GetShops();
        return Ok(shops);
    }
    
    [HttpPost("buy_product")]//TODO patch
    public async Task<ActionResult> BuyProduct([FromBody] BuyProductRequest request)
    {
        var changeReceived = await _shopServices.Buy(request);
        return  Ok(changeReceived);
    }
  
    
}