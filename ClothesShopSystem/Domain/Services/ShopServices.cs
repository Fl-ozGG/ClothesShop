using ClothesShopSystem.API.DTOs;
using ClothesShopSystem.Domain.Entities;
using ClothesShopSystem.Domain.Repositories;
using ClothesShopSystem.Infrastructure.Repository;

namespace ClothesShopSystem.Domain.Services;

public class ShopServices(IShopRepository shopRepository, IUserRepository userRepository,  IProductRepository productRepository)
{
    public async Task<Shop> Create(CreateShopRequest request)
    {
        var addressDontExist = await shopRepository.AddressDontExists(request.ShopAddress);
        if (!addressDontExist)
        {
            throw new Exception("This address is already used by another shop.");
        }

        var userIsDirective = await userRepository.IsDirective(request.DirectiveId);
        if (!userIsDirective)
        {
            throw new Exception("This user type is not able to create a shop.");
        }
        var shop = new Shop(request.ShopName, request.ShopAddress, request.DirectiveId);
        return await shopRepository.Persist(shop);
    }

    public async Task<List<Shop>> GetShops()
    {
        return await shopRepository.GetShops();
    }

    public async Task<string> Buy(BuyProductRequest request)
    {
        var product = await productRepository.GetProduct(request.ProductId);
        if(product.Stock < request.Amount) throw new Exception("Not enough stock");
        if(request.AmountOfCash < product.GetAmountPrice(request.Amount)) throw new Exception("Not enough cash.");
        var cashChange = request.AmountOfCash - product.GetAmountPrice(request.Amount);
        await shopRepository.Buy(product, request.Amount);
        return $"Transaction Complete.\nThe total change to return is: {cashChange}$.";
    }
}
