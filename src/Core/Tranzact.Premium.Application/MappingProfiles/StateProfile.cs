using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Features.State.Query.GetStates;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.MappingProfiles
{
    public class StateProfile : Profile
    {
        public StateProfile()
        {
            CreateMap<GetStateDto, State>().ReverseMap();
        }
    }
}
