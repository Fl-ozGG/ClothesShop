namespace ClothesShopSystem.Domain.Entities;

public class Product
{
    public Guid Id { get; init; }
    public Guid ShopId { get; set; }
    public Guid SupplierId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public Product(string name, decimal price, int stock, Guid supplierId)
    {
        
        Name = name;
        Price = price;
        Stock = stock;
        SupplierId =  supplierId;
        
    }
    
    protected Product() { }

    public decimal GetAmountPrice(int amount)
    {
        return (Price * amount);
    }
}