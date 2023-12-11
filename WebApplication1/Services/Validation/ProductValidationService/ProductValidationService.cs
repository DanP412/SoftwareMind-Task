using NegotiationApp.Entities.DTOs.Product;

namespace NegotiationApp.Services.Validation.Product
{
    public class ProductValidationService : IProductValidationService
    {
        public string ValidateProduct(ProductCreateDto product)
        {
            if (product == null)
            {
                return "Product cannot be empty!";
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return "Product name cannot be empty!";
            }

            if (product.Price < 0)
            {
                return "Price of the product must be positive!";
            }

            else return string.Empty;
        }
    }
}
