using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Contracts.Logging;
using Tranzact.Premium.Application.Contracts.Persistence;
using Tranzact.Premium.Application.Features.Plan.Query.GetPlans;
using Tranzact.Premium.Application.Features.Premium.Shared;

namespace Tranzact.Premium.Application.Features.Premium.Command.CalcPremium
{
    public class CalcPremiumCommandHandler : IRequestHandler<CalcPremiumCommand, List<GetPremiumDto>>
    {
        private readonly IPremiumRepository _premiumRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetPlanHandler> _logger;

        public CalcPremiumCommandHandler(IPremiumRepository premiumRepository, IMapper mapper, IAppLogger<GetPlanHandler> logger)
        {
            _premiumRepository = premiumRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetPremiumDto>> Handle(CalcPremiumCommand request, CancellationToken cancellationToken)
        {
            var list = await _premiumRepository.CalcPremiumAsync(request);
            var finalData = _mapper.Map<List<GetPremiumDto>>(list);

            _logger.LogInformation("Premiums were retrieved successfully");
            return finalData;
        }
    }
}
