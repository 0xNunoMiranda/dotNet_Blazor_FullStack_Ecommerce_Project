using EcommerceShopLibrary.Models;
using Microsoft.EntityFrameworkCore;


namespace EcommerceShopServer.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
            
        }
        public DbSet<Product> Products { get; set; } = default!;
    }
}
