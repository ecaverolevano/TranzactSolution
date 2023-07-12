using AutoMapper;
using MediatR;
using Tranzact.Premium.Application.Contracts.Logging;
using Tranzact.Premium.Application.Contracts.Persistence;
using Tranzact.Premium.Application.Features.Plan.Query.GetPlans;
using Tranzact.Premium.Application.Features.Premium.Shared;

namespace Tranzact.Premium.Application.Features.Premium.Query.GetPremiums
{
    public class GetPremiumHandler : IRequestHandler<GetPremiumQuery, List<GetPremiumDto>>
    {
        private readonly IPremiumRepository _premiumRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetPremiumHandler> _logger;

        public GetPremiumHandler(IPremiumRepository premiumRepository, IMapper mapper, IAppLogger<GetPremiumHandler> logger)
        {
            _premiumRepository = premiumRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetPremiumDto>> Handle(GetPremiumQuery request, CancellationToken cancellationToken)
        {
            var list = await _premiumRepository.GetPremiumWithPlansAsync();
            var finalData = _mapper.Map<List<GetPremiumDto>>(list);

            _logger.LogInformation("Premiums were retrieved successfully");
            return finalData;
        }
    }
}
