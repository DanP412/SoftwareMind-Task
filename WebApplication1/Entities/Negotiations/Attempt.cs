namespace NegotiationApp.Entities.Negotiations
{
    public class Attempt
    {
        public int Id { get; set; }
        public int NegotiationId { get; set; }
        public DateTime Date { get; set; }
        public Negotiation Negotiation { get; set; }
    }
}
