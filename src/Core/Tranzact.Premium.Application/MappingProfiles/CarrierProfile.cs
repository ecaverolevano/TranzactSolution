using AutoMapper;
using Tranzact.Premium.Application.Features.Carrier.Query.GetCarriers;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.MappingProfiles
{
    public class CarrierProfile : Profile
    {
        public CarrierProfile()
        {
            CreateMap<GetCarrierDto, Carrier>().ReverseMap();
        }
    }
}
