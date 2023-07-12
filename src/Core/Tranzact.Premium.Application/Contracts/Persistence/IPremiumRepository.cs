using MediatR;
using Tranzact.Premium.Application.Features.Premium.Command.CalcPremium;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.Contracts.Persistence
{
    public interface IPremiumRepository : IGenericRepository<PremiumData>
    {
        Task<List<PremiumData>> CalcPremiumAsync(CalcPremiumCommand request);
        Task<List<PremiumData>> GetPremiumWithPlansAsync();
        Task<PremiumData> GetPremiumByIdWithPlansAsync(int id);

        Task UpdatePremium(PremiumData premiumData);

    }
}
