using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.Features.Premium.Shared
{
    public class GetPremiumDto
    {
        public int Id { get; set; }
        public string Carrier { get; set; }
        public string State { get; set; }
        public int MonthOfBirth { get; set; }
        public int AgeRangeMin { get; set; }
        public int AgeRangeMax { get; set; }
        public decimal Premium { get; set; }

        public List<PremiumDataPlan> ListPlans { get; set; }
    }
}
