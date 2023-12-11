namespace NegotiationApp.Entities.DTOs.Negotiation
{
    public class NegotiationCreateDto
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public decimal ProposedPrice { get; set; }
    }
}
