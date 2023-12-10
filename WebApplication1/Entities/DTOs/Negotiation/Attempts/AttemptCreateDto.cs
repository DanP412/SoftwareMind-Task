namespace NegotiationApp.Entities.DTOs.Negotiation.Attempts
{
    public class AttemptCreateDto
    {
        public DateTime Date { get; set; }
        public int NegotiationTries { get; set; }
    }
}
