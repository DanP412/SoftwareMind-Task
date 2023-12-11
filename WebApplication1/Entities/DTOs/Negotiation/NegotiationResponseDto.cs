using NegotiationApp.Entities.Negotiations;
using WebApplication1.Models.Users;

namespace NegotiationApp.Entities.DTOs.Negotiation
{
    public class NegotiationResponseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public decimal ProposedPrice { get; set; }
        public string Status { get; set; }
        public ICollection<Attempt> Attempts { get; set; }
    }
}
