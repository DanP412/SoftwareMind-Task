using NegotiationApp.Entities.Products;

namespace NegotiationApp.Services.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
