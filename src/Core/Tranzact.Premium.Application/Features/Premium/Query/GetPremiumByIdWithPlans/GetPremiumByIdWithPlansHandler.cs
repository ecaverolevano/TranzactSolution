using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Contracts.Logging;
using Tranzact.Premium.Application.Contracts.Persistence;
using Tranzact.Premium.Application.Features.Premium.Query.GetPremiums;
using Tranzact.Premium.Application.Features.Premium.Shared;

namespace Tranzact.Premium.Application.Features.Premium.Query.GetPremiumByIdWithPlans
{
    public class GetPremiumByIdWithPlansHandler : IRequestHandler<GetPremiumByIdWithPlansQuery, GetPremiumDto>
    {
        private readonly IPremiumRepository _premiumRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetPremiumByIdWithPlansHandler> _logger;

        public GetPremiumByIdWithPlansHandler(IPremiumRepository premiumRepository, IMapper mapper, IAppLogger<GetPremiumByIdWithPlansHandler> logger)
        {
            _premiumRepository = premiumRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetPremiumDto> Handle(GetPremiumByIdWithPlansQuery request, CancellationToken cancellationToken)
        {
            var list = await _premiumRepository.GetPremiumByIdWithPlansAsync(request.id);
            var finalData = _mapper.Map<GetPremiumDto>(list);

            _logger.LogInformation("Premiums were retrieved successfully");
            return finalData;
        }
    }
}
