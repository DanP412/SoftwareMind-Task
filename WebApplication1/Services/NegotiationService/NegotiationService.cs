using Microsoft.EntityFrameworkCore;
using NegotiationApp.Data.Entities.Configuration;
using NegotiationApp.Entities.DTOs.Negotiation;
using NegotiationApp.Entities.Negotiations;

namespace NegotiationApp.Services.NegotiationService
{
    public class NegotiationService : INegotiationService
    {
        private readonly NegotiaionAppDbContext _negotiaionAppDbContext;
        public NegotiationService(NegotiaionAppDbContext context)
        {
            _negotiaionAppDbContext = context;
        }

        public async Task<IEnumerable<NegotiationResponseDto>> GetAllNegotiationsAsync()
        {
            var negotiations = await _negotiaionAppDbContext.Negotiations.Include(n => n.Attempts).ToListAsync();
            var negotiationsResponse = negotiations.Select(negotiation => new NegotiationResponseDto
            {
                Id = negotiation.Id,
                ProductId = negotiation.ProductId,
                CustomerId = negotiation.CustomerId,
                EmployeeId = negotiation.EmployeeId,
                ProposedPrice = negotiation.ProposedPrice,
                Status = negotiation.Status,
                Attempts = negotiation.Attempts
            }).ToList();

            return negotiationsResponse;
        }

        public async Task<NegotiationResponseDto> GetNegotiationByIdAsync(int id)
        {
            var negotiation = await _negotiaionAppDbContext.Negotiations
                .Include(n => n.Attempts)
                .FirstOrDefaultAsync(n => n.Id == id);

            var negotiationResponse = new NegotiationResponseDto
            {
                Id = negotiation.Id,
                CustomerId = negotiation.CustomerId,
                EmployeeId = negotiation.EmployeeId,
                ProductId = negotiation.ProductId,
                ProposedPrice = negotiation.ProposedPrice,
                Status = negotiation.Status,
                Attempts = negotiation.Attempts
            };

            return negotiationResponse;
        }

        public async Task<Negotiation> AddNegotiationAsync(NegotiationCreateDto negotiationToCreate)
        {
            Negotiation newNegotiation = new Negotiation
            {
                CustomerId = negotiationToCreate.CustomerId,
                EmployeeId = negotiationToCreate.EmployeeId,
                ProductId = negotiationToCreate.ProductId,
                ProposedPrice = negotiationToCreate.ProposedPrice,
                Status = "Pending",
                Attempts = new List<Attempt> 
                {
                    new Attempt 
                    {
                        Date = DateTime.Now
                    }
                }
            };

            _negotiaionAppDbContext.Negotiations.Add(newNegotiation);
            await _negotiaionAppDbContext.SaveChangesAsync();

            return newNegotiation;
        }

        public async Task<Negotiation> UpdateNegotiationAsync(int id, NegotiationUpdateDto updatedNegotiation)
        {
            var negotiation = await _negotiaionAppDbContext.Negotiations.FindAsync(id);

            negotiation.ProposedPrice = updatedNegotiation.ProposedPrice;
            negotiation.Status = updatedNegotiation.Status;

            negotiation.Attempts = new List<Attempt>
            {
                new Attempt
                {
                   Date = DateTime.Now
                }
            };

            _negotiaionAppDbContext.Entry(negotiation).State = EntityState.Modified;
            await _negotiaionAppDbContext.SaveChangesAsync();

            return negotiation;
        } 
        public async Task<Negotiation> UpdateNegotiationStatusAsync(int id, NegotiationStatusUpdateDto UpdatedNegotiationStatus)
        {
            var negotiationStatus = await _negotiaionAppDbContext.Negotiations.FindAsync(id);

            negotiationStatus.Status = UpdatedNegotiationStatus.Status;

            _negotiaionAppDbContext.Entry(negotiationStatus).State = EntityState.Modified;
            await _negotiaionAppDbContext.SaveChangesAsync();

            return negotiationStatus;
        }

        public async Task<bool> DeleteNegotiationAsync(int id)
        {
            var negotiationToDelete = await _negotiaionAppDbContext.Negotiations.FindAsync(id);

            if (negotiationToDelete != null)
            {
                _negotiaionAppDbContext.Negotiations.Remove(negotiationToDelete);
                await _negotiaionAppDbContext.SaveChangesAsync();

                return true;
            }

            else return false;
        }
    }
}
