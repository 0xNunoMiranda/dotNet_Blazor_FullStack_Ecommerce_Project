using EcommerceShopLibrary.Models;
using EcommerceShopLibrary.Responses;

namespace EcommerceShopLibrary.Contracts
{
    public interface IProduct
    {
        Task<ServiceResponse> AddProduct(Product model);
        Task<List<Product>> GetAllProducts(bool featureProducts);
    }
}
