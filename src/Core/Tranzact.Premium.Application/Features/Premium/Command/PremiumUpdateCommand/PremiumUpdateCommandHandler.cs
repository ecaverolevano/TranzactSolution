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
using Tranzact.Premium.Application.Features.Premium.Query;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.Features.Premium.Command.PremiumUpdateCommand
{
    public class PremiumUpdateCommandHandler : IRequestHandler<PremiumUpdateCommandRequest, Unit>
    {
        private readonly IPremiumRepository _premiumRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PremiumUpdateCommandHandler> _logger;

        public PremiumUpdateCommandHandler(IPremiumRepository premiumRepository, IMapper mapper, IAppLogger<PremiumUpdateCommandHandler> logger)
        {
            _premiumRepository = premiumRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(PremiumUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<PremiumData>(request.PremiumData);
            await _premiumRepository.UpdatePremium(data);

            _logger.LogInformation("Premiums were retrieved successfully");
            return Unit.Value;
        }
    }
}
