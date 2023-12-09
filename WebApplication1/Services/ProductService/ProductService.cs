using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegotiationApp.Data.Entities.Configuration;
using NegotiationApp.Entities.Products;

namespace NegotiationApp.Services.ProductService
{
    public class ProductService: IProductService
    {
        private readonly NegotiaionAppDbContext _negotiaionAppDbContext;

        public ProductService(NegotiaionAppDbContext context)
        {
            _negotiaionAppDbContext = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _negotiaionAppDbContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _negotiaionAppDbContext.Products.FindAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            _negotiaionAppDbContext.Products.Add(product);
            await _negotiaionAppDbContext.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _negotiaionAppDbContext.Entry(product).State = EntityState.Modified;
            await _negotiaionAppDbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _negotiaionAppDbContext.Products.FindAsync(id);
            if (product != null)
            {
                _negotiaionAppDbContext.Products.Remove(product);
                await _negotiaionAppDbContext.SaveChangesAsync();
            }
        }
    }
}
