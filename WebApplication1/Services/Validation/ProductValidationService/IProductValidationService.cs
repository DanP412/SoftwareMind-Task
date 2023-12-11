using NegotiationApp.Entities.DTOs.Product;

namespace NegotiationApp.Services.Validation.Product
{
    public interface IProductValidationService
    {
        string ValidateProduct(ProductCreateDto product);
    }
}
