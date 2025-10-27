using ClothesShopSystem.Domain.Entities;

namespace ClothesShopSystem.API.DTOs;

public class CreateProductRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Guid SupplierId { get; set; }
}