using Microsoft.EntityFrameworkCore;
using NegotiationApp.Data.Entities.Configuration;
using NegotiationApp.Entities.Negotiations;
using NegotiationApp.Services.ProductService;

namespace NegotiationApp.Services.NegotiationService
{
    public class NegotiationService : INegotiationService
    {
        private readonly NegotiaionAppDbContext _negotiaionAppDbContext;
        public NegotiationService(NegotiaionAppDbContext context)
        {
            _negotiaionAppDbContext = context;
        }

        public async Task<IEnumerable<Negotiation>> GetAllNegotiationsAsync()
        {
            return await _negotiaionAppDbContext.Negotiations.Include(n => n.Attempts).ToListAsync();
        }

        public async Task<Negotiation> GetNegotiationByIdAsync(int id)
        {
            return await _negotiaionAppDbContext.Negotiations
                .Include(n => n.Attempts)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Negotiation> AddNegotiationAsync(Negotiation negotiation)
        {
            _negotiaionAppDbContext.Negotiations.Add(negotiation);
            await _negotiaionAppDbContext.SaveChangesAsync();
            return negotiation;
        }

        public async Task UpdateNegotiationAsync(Negotiation negotiation)
        {
            _negotiaionAppDbContext.Entry(negotiation).State = EntityState.Modified;
            await _negotiaionAppDbContext.SaveChangesAsync();
        }

        public async Task DeleteNegotiationAsync(int id)
        {
            var negotiation = await _negotiaionAppDbContext.Negotiations.FindAsync(id);
            if (negotiation != null)
            {
                _negotiaionAppDbContext.Negotiations.Remove(negotiation);
                await _negotiaionAppDbContext.SaveChangesAsync();
            }
        }
    }
}
