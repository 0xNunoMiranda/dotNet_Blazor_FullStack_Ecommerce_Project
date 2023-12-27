using EcommerceShopLibrary.Contracts;
using EcommerceShopLibrary.Models;
using EcommerceShopLibrary.Responses;
using EcommerceShopServer.Data;
using Microsoft.EntityFrameworkCore;

namespace EcommerceShopServer.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly AppDbContext appDbContext;
        public ProductRepository(AppDbContext _appDbContext) { 
            this.appDbContext = _appDbContext;
        }
        public async Task<ServiceResponse> AddProduct(Product model)
        {
            if (model is null) return new ServiceResponse(false,"Model is null");
            var (flag,message) = await CheckName(model.Name);
            if (flag)
            {
                appDbContext.Products.Add(model);
                await Commit();
                return new ServiceResponse(true, "Product Saved");
            }
            return new ServiceResponse(flag,message);


        }

        public async Task<List<Product>> GetAllProducts(bool featureProducts)
        {
            if(featureProducts)
                return await appDbContext.Products.Where( _ =>_.Featured).ToListAsync();
            else
                return await appDbContext.Products.ToListAsync();
        }

        private async Task<ServiceResponse> CheckName(string name)
        {
            var product = await this.appDbContext.Products.FirstOrDefaultAsync(x => x.Name.ToLower() != name.ToLower());
            return product is null ? new ServiceResponse(true, null) : new ServiceResponse(false, "Product already exist");
        }

        private async Task Commit() => await appDbContext.SaveChangesAsync();

    }
}
