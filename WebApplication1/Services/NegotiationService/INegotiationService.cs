using NegotiationApp.Entities.DTOs.Negotiation;
using NegotiationApp.Entities.Negotiations;

namespace NegotiationApp.Services.NegotiationService
{
    public interface INegotiationService
    {
        Task<Negotiation> AddNegotiationAsync(NegotiationCreateDto negotiationToCreate);
        Task<bool> DeleteNegotiationAsync(int id);
        Task<IEnumerable<NegotiationResponseDto>> GetAllNegotiationsAsync();
        Task<NegotiationResponseDto> GetNegotiationByIdAsync(int id);
        Task<NegotiationResponseDto> UpdateNegotiationAsync(int id, NegotiationUpdateDto updatedNegotiation);
        Task<Negotiation> UpdateNegotiationStatusAsync(int id, NegotiationStatusUpdateDto UpdatedNegotiationStatus);
    }
}
