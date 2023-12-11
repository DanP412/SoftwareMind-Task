using NegotiationApp.Data.Entities.Configuration;
using NegotiationApp.Entities.DTOs.Negotiation;

namespace NegotiationApp.Services.Validation.NegotiationValidationService
{
    public class NegotiationValidationService: INegotiationValidationService
    {
        private readonly NegotiaionAppDbContext _negotiaionAppDbContext;
        public NegotiationValidationService(NegotiaionAppDbContext negotiaionAppDbContext)
        {
            _negotiaionAppDbContext = negotiaionAppDbContext;
        }
        public string ValidateNegotiation(NegotiationCreateDto negotiation)
        {
            if (negotiation == null)
            {
                return "Negotiation cannot be empty!";
            }
            else if (negotiation.ProposedPrice <= 0)
            {
                return "Proposed price must be posistive!";
            }
            else if (negotiation.Status == "Closed")
            {
                return "You have reached the limit of your attempts at negotiation";
            }
            else return string.Empty;
        }

        public bool ProposedPriceIsValid(NegotiationCreateDto negotiation, decimal productPrice)
        {
            if (negotiation.ProposedPrice < (productPrice / 2))
            {
                negotiation.Status = "Rejected";
                return false;
            }

            else return true;
        }
        public async Task<bool> CheckIfNegotiationAlreadyExist(int productId, int customerId)
        {
            return _negotiaionAppDbContext.Negotiations
                .Any(n => n.ProductId == productId && n.CustomerId == customerId);
        }
    }
}
