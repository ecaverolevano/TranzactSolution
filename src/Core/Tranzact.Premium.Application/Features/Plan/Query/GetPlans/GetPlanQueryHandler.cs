using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Contracts.Logging;
using Tranzact.Premium.Application.Contracts.Persistence;
using Tranzact.Premium.Application.Features.Carrier.Query.GetCarriers;

namespace Tranzact.Premium.Application.Features.Plan.Query.GetPlans
{
    public class GetPlanHandler : IRequestHandler<GetPlanQuery, List<GetPlanDto>>
    {
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetPlanHandler> _logger;

        public GetPlanHandler(IPlanRepository planRepository, IMapper mapper, IAppLogger<GetPlanHandler> logger)
        {
            _planRepository = planRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetPlanDto>> Handle(GetPlanQuery request, CancellationToken cancellationToken)
        {
            var list = await _planRepository.GetAsync();
            var finalData = _mapper.Map<List<GetPlanDto>>(list);

            _logger.LogInformation("Plans were retrieved successfully");
            return finalData;
        }
    }
}
