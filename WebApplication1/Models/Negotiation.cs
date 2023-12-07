using WebApplication1.Models.Products;

namespace WebApplication1.Models
{
    public class Negotiation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public List<Repetition> Repetitions { get; set; }

    }
}
