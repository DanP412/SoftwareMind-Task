using NegotiationApp.Entities.DTOs.Negotiation.Attempts;

namespace NegotiationApp.Entities.DTOs.Negotiation
{
    public class NegotiationCreateDto
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public decimal ProposedPrice { get; set; }
        public string Status { get; set; }
        public List<AttemptCreateDto> Attempts { get; set; }
    }
}
