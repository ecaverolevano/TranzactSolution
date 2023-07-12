using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Features.Plan.Query.GetPlans;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.MappingProfiles
{
    public class PlanProfile : Profile
    {
        public PlanProfile()
        {
            CreateMap<GetPlanDto, Plan>().ReverseMap();
        }
    }
}
