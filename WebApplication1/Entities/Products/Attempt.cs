using NegotiationApp.Entities.Negotiations;

namespace NegotiationApp.Entities.Products
{
    public class Attempt
    {
        public int Id { get; set; }
        public int NegotiationId { get; set; }
        public DateTime Date { get; set; }
        public int NegotiationTries { get; set; }
        public Negotiation Negotiation { get; set; }
    }
}
