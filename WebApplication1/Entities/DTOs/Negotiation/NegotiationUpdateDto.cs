namespace NegotiationApp.Entities.DTOs.Negotiation
{
    public class NegotiationUpdateDto
    {
        public decimal ProposedPrice { get; set; }
        public string Status { get; set; }
        public int ProductId { get; set; }
    }
}
