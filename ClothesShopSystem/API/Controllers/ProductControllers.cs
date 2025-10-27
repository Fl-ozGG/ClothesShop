using ClothesShopSystem.API.DTOs;
using ClothesShopSystem.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShopSystem.API.Controllers;


[ApiController]
[Route("api/[controller]")]

public class ProductController(ProductServices productServices) : ControllerBase
{
    [HttpPost("create_product")]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        var product = await productServices.CreateProduct(request);
        return Ok(product);
    }

    [HttpPost("add_product")]
    public async Task<ActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        await productServices.AddProduct(request);
        return Ok("Product added.");
    }

    [HttpGet("get_products")]
    public async Task<ActionResult> GetProducts()
    {
        var products = await productServices.GetProducts();
        return Ok(products);
    }
}