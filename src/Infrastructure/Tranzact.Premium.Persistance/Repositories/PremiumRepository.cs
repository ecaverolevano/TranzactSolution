using MediatR;
using Microsoft.EntityFrameworkCore;
using Tranzact.Premium.Application.Contracts.Persistence;
using Tranzact.Premium.Application.Features.Premium.Command.CalcPremium;
using Tranzact.Premium.Domain;
using Tranzact.Premium.Persistence.DatabaseContext;

namespace Tranzact.Premium.Persistence.Repositories
{
    public class PremiumRepository : GenericRepository<PremiumData>, IPremiumRepository
    {
        public PremiumRepository(PremiumDatabaseContext context) : base(context)
        {
        }

        public async Task<List<PremiumData>> CalcPremiumAsync(CalcPremiumCommand request)
        {
            var data = await _context.PremiumData.Include(x => x.ListPlans) .Where(x =>
                (x.MonthOfBirth == request.DateOfBirth.Month || x.MonthOfBirth == 0)
                && x.State == request.State
                && (x.AgeRangeMin <= request.Age && x.AgeRangeMax >= request.Age)
                && x.ListPlans.Where(plan => plan.PlanId == request.PlanId).Count() >= 1
            ).ToListAsync();

            return data;
        }

        public async Task<PremiumData> GetPremiumByIdWithPlansAsync(int id)
        {
            var data = await _context.PremiumData
                .Include(q => q.ListPlans)
                .SingleOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<List<PremiumData>> GetPremiumWithPlansAsync()
        {
            var data = await _context.PremiumData
               .Include(q => q.ListPlans)
               .ToListAsync();
            return data;
        }

        public async Task UpdatePremium(PremiumData premiumData)
        {
            var data = _context.PremiumData.Include(x => x.ListPlans).SingleOrDefault(x => x.Id == premiumData.Id);
            if (data != null)
            {
                _context.Entry(data).CurrentValues.SetValues(premiumData);

                // Update the 'listPlans' collection
                UpdateListPlans(data, premiumData.ListPlans);
                await _context.SaveChangesAsync();
            }

        }

        private void UpdateListPlans(PremiumData trackedEntity, List<PremiumDataPlan> updatedListPlans)
        {
            // Remove any existing listPlans not present in the updated list
            var removedListPlans = trackedEntity.ListPlans
                .Where(lp => !updatedListPlans.Any(up => up.PremiumDataId == lp.PremiumDataId && up.PlanId == lp.PlanId))
                .ToList();
            removedListPlans.ForEach(lp => trackedEntity.ListPlans.Remove(lp));

            // Add new listPlans not already in the tracked entity
            var newListPlans = updatedListPlans
                .Where(up => !trackedEntity.ListPlans.Any(lp => lp.PremiumDataId == up.PremiumDataId && lp.PlanId == up.PlanId))
                .ToList();
            newListPlans.ForEach(lp => trackedEntity.ListPlans.Add(lp));
        }
    }
}
