using System.ComponentModel.DataAnnotations;
using Tranzact.Premium.Domain.Common;

namespace Tranzact.Premium.Domain
{
    public class PremiumData : BaseAuditableEntity
    {
        //[Key]
        //public int Id { get; set; }
        public string Carrier { get; set; }
        public string State { get; set; }
        public int MonthOfBirth { get; set; }
        public int AgeRangeMin { get; set; }
        public int AgeRangeMax { get; set; }
        public decimal Premium { get; set; }
        public List<PremiumDataPlan> ListPlans { get; set; }
    }

    public class PremiumDataPlan
    {
        public int PremiumDataId { get; set; }

        public int PlanId { get; set; }
        public string Code { get; set; }
    }

    
}
