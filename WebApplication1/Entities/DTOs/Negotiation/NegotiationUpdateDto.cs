using NegotiationApp.Entities.Negotiations;

namespace NegotiationApp.Entities.DTOs.Negotiation
{
    public class NegotiationUpdateDto
    {
        public decimal ProposedPrice { get; set; }
        public string Status { get; set; }
        public ICollection<Attempt> Attempts { get; set; }
    }
}
