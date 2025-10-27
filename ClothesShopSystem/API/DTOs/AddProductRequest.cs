namespace ClothesShopSystem.API.DTOs;

public class AddProductRequest
{
    public  Guid ShopId { get; set; }
    public Guid SupplierId { get; set; }
    public Guid ProductId { get; set; }
}
