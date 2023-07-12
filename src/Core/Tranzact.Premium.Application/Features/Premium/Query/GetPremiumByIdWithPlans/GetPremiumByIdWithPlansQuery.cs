using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Features.Premium.Shared;

namespace Tranzact.Premium.Application.Features.Premium.Query.GetPremiumByIdWithPlans
{
    public class GetPremiumByIdWithPlansQuery : IRequest<GetPremiumDto>
    {
        public int id { get; set; }
    }
}
