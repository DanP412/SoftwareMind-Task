using NegotiationApp.Entities.DTOs.Negotiation;

namespace NegotiationApp.Services.Validation.NegotiationValidationService
{
    public interface INegotiationValidationService
    {
        Task<bool> CheckIfNegotiationAlreadyExist(int productId, int customerId);
        bool ProposedPriceIsValid(NegotiationCreateDto negotiation, decimal productPrice);
        string ValidateNegotiation(NegotiationCreateDto negotiation);
    }
}
