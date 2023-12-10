using NegotiationApp.Entities.Products;
using WebApplication1.Models.Users;

namespace NegotiationApp.Entities.Negotiations
{
    public class Negotiation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public decimal ProposedPrice { get; set; }
        public string Status { get; set; }
        public ICollection<Attempt> Attempts { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
    }
}
