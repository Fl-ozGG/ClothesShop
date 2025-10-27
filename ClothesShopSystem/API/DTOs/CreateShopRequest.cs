namespace ClothesShopSystem.API.DTOs;

public class CreateShopRequest
{
    public string ShopName { get; set; }
    public string ShopAddress { get; set; }
    public Guid DirectiveId { get; set; }
}