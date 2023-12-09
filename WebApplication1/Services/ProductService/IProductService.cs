using NegotiationApp.Entities.DTOs;
using NegotiationApp.Entities.Products;

namespace NegotiationApp.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(ProductCreateDto productToCreate);
        Task<Product> UpdateProductAsync(int id, ProductUpdateDto updatedProduct);
        Task<bool> DeleteProductAsync(int id);
    }
}
