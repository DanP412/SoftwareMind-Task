using NegotiationApp.Entities.Products;

namespace NegotiationApp.Entities.Negotiations
{
    public class Negotiation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public string Status { get; set; }
        public ICollection<Attempt> Attempts { get; set; }
    }
}
