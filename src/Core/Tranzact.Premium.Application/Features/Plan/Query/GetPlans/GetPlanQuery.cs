using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Premium.Application.Features.Plan.Query.GetPlans
{
    public class GetPlanQuery : IRequest<List<GetPlanDto>>
    {
    }
}
