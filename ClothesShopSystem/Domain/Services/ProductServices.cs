using ClothesShopSystem.API.DTOs;
using ClothesShopSystem.Domain.Entities;
using ClothesShopSystem.Domain.Repositories;

namespace ClothesShopSystem.Domain.Services;

public class ProductServices
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IShopRepository _shopRepository;

    public ProductServices(IProductRepository productRepository, IUserRepository userRepository, IShopRepository shopRepository)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
        _shopRepository = shopRepository;
    }

    public async Task<Product> CreateProduct(CreateProductRequest  request)
    {
        var isSupplier = await _userRepository.IsSupplier(request.SupplierId);
        if (request.Stock == 0)
        {
            throw new ArgumentException("Stock must be greater than 0");
        }

        if (!isSupplier)
        {
            throw new ArgumentException("User is not supplier.");
        }
        else
        {
            var product = new Product(request.Name, request.Price, request.Stock, request.SupplierId);
            return await _productRepository.Persist(product);
        }
    }

    public async Task<Product> AddProduct(AddProductRequest request)
    {
        var validUser = await _userRepository.IsSupplier(request.SupplierId);
        if (!validUser)
        {
            throw new ArgumentException("User is not supplier.");
        }
        var userOwnsProduct = await _userRepository.OwnsProduct(request.SupplierId, request.ProductId);
        if (!userOwnsProduct)
        {
            throw new ArgumentException("This Supplier does not own that product.");
        }
        var shopExists = await _shopRepository.ShopExists(request.ShopId);
        if (!shopExists)
        {
            throw new ArgumentException("Shop does not exist.");
        }
        var productToAdd = await _productRepository.GetProduct(request.ProductId);
        await _productRepository.AddProduct(productToAdd, request.ShopId);
        return productToAdd; 
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _productRepository.GetProducts();
    }
    
    
}