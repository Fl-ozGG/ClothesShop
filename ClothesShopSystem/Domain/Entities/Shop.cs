namespace ClothesShopSystem.Domain.Entities;

public class Shop
{
    public Guid Id { get; set; }
    public Guid DirectiveId { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }


    public Shop(string name, string adress, Guid directiveId)
    {
        Name = name;
        Adress = adress;
        DirectiveId = directiveId;
    }

  
}