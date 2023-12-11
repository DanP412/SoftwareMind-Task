using NegotiationApp.Entities.DTOs.Negotiation;
using NegotiationApp.Entities.Negotiations;

namespace NegotiationApp.Services.Validation.NegotiationValidationService
{
    public interface INegotiationValidationService
    {
        Negotiation CheckNegotiationEmployee(Negotiation negotiation);
        Task<bool> CheckIfNegotiationAlreadyExist(int productId, int customerId);
        bool ProposedPriceIsValid(Negotiation negotiation, decimal productPrice);
        string ValidateNegotiation(Negotiation negotiation);
        Task<bool> NegotiationExist(int negotiationId);
    }
}
