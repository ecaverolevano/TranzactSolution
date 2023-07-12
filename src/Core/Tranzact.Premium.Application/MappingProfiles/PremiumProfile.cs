using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Features.Premium.Command.PremiumUpdateCommand;
using Tranzact.Premium.Application.Features.Premium.Shared;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.MappingProfiles
{
    public class PremiumProfile : Profile
    {
        public PremiumProfile()
        {
            CreateMap<GetPremiumDto, PremiumData>().ReverseMap();
            CreateMap<PremiumUpdateCommandRequest, PremiumData>().ReverseMap();



            //CreateMap<Presupuesto, BudgetDTO>()
            //.ForMember(p => p.Id, x => x.MapFrom(d => d.Id))
            //.ForMember(p => p.Cuenta, x => x.MapFrom(d => d.Cuenta.Nombre))
            //.ForMember(p => p.EstimadoFinanciero, x => x.MapFrom(d => d.EstimadoFinanciero))
            //.ForMember(p => p.Opurtunidad, x => x.MapFrom(d => d.Opurtunidad))
            //.ForMember(p => p.FechaInicio, x => x.MapFrom(d => d.FechaInicio.ToString("dd/MM/yyyy")))
            //.ForMember(p => p.FechaFin, x => x.MapFrom(d => d.FechaFin.ToString("dd/MM/yyyy")))
            //.ForMember(p => p.Duracion, x => x.MapFrom(d => d.Duracion))
            //.ForMember(p => p.Estado, x => x.MapFrom(d => d.Estado));


        }
    }
}
