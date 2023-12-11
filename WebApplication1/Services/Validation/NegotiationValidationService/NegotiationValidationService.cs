using NegotiationApp.Data.Entities.Configuration;
using NegotiationApp.Entities.DTOs.Negotiation;
using NegotiationApp.Entities.Negotiations;

namespace NegotiationApp.Services.Validation.NegotiationValidationService
{
    public class NegotiationValidationService: INegotiationValidationService
    {
        private readonly NegotiaionAppDbContext _negotiaionAppDbContext;
        public NegotiationValidationService(NegotiaionAppDbContext negotiaionAppDbContext)
        {
            _negotiaionAppDbContext = negotiaionAppDbContext;
        }
        public string ValidateNegotiation(Negotiation negotiation)
        {
            if (negotiation == null)
            {
                return "Negotiation cannot be empty!";
            }
            else if (negotiation.ProposedPrice <= 0)
            {
                return "Proposed price must be posistive!";
            }
            else return string.Empty;
        }

        public bool ProposedPriceIsValid(Negotiation negotiation, decimal productPrice)
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
                .Any(n =>  n.ProductId == productId && n.CustomerId == customerId);
        }
        public async Task<bool> NegotiationExist(int negotiationId)
        {
            return _negotiaionAppDbContext.Negotiations
                .Any(n =>  n.Id == negotiationId);
        }
        public Negotiation CheckNegotiationEmployee(Negotiation negotiation)
        {
            if (negotiation.EmployeeId == 0)
            {
                negotiation.EmployeeId = null;
            }

            return negotiation;
        }
    }
}
