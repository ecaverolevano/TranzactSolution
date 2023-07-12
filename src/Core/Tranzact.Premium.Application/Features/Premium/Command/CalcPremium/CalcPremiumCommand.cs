using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Features.Premium.Shared;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.Features.Premium.Command.CalcPremium
{
    public class CalcPremiumCommand : IRequest<List<GetPremiumDto>>
    {
        public DateTime DateOfBirth { get; set; }
        public string? State { get; set; }
        public int Age { get; set; }
        public int PlanId { get; set; }
    }
}
