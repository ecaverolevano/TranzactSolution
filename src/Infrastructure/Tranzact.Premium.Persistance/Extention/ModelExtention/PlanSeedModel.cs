using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Persistence
{
    public class PlanSeedModel
    {
        public Plan[] Plans { get; set; }
        public Carrier[] Carriers  { get; set; }
        public State[] States { get; set; }
        public PremiumData[] Premium { get; set; }
        public PremiumDataPlan[] PremiumDataPlan { get; set; }

    }
}
