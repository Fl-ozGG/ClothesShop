namespace ClothesShopSystem.API.DTOs;

public class BuyProductRequest
{
    public Guid ProductId { get; set; }
    public int Amount { get; set; }
    public decimal AmountOfCash { get; set; }
}