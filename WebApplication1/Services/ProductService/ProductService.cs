using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NegotiationApp.Data.Entities.Configuration;
using NegotiationApp.Entities.DTOs.Product;
using NegotiationApp.Entities.Products;

namespace NegotiationApp.Services.ProductService
{
    public class ProductService : IProductService
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

        public async Task<Product> CreateProductAsync(ProductCreateDto productToCreate)
        {
            var newPoduct = new Product
            {
                Name = productToCreate.Name,
                Price = productToCreate.Price
            };

            _negotiaionAppDbContext.Products.Add(newPoduct);
            await _negotiaionAppDbContext.SaveChangesAsync();

            return newPoduct;
        }

        public async Task<Product> UpdateProductAsync(int id, ProductUpdateDto updatedProduct)
        {
            var product = await _negotiaionAppDbContext.Products.FindAsync(id);

            product.Price = updatedProduct.Price;
            product.Name = updatedProduct.Name;

            _negotiaionAppDbContext.Entry(product).State = EntityState.Modified;
            await _negotiaionAppDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _negotiaionAppDbContext.Products.FindAsync(id);
            bool productExist = product != null;

            if (productExist)
            {
                _negotiaionAppDbContext.Products.Remove(product);
                await _negotiaionAppDbContext.SaveChangesAsync();
                return true;
            }

            else return false;
        }
    }
}
