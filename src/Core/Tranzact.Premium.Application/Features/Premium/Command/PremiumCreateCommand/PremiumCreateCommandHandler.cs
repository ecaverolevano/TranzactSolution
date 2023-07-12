using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Contracts.Logging;
using Tranzact.Premium.Application.Contracts.Persistence;
using Tranzact.Premium.Application.Features.Premium.Command.PremiumUpdateCommand;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.Features.Premium.Command.PremiumCreateCommand
{
    public class PremiumCreateCommandHandler : IRequestHandler<PremiumCreateCommandRequest, Unit>
    {
        private readonly IPremiumRepository _premiumRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PremiumCreateCommandHandler> _logger;

        public PremiumCreateCommandHandler(IPremiumRepository premiumRepository, IMapper mapper, IAppLogger<PremiumCreateCommandHandler> logger)
        {
            _premiumRepository = premiumRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(PremiumCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<PremiumData>(request.premiumData);
            await _premiumRepository.CreateAsync(data);

            _logger.LogInformation("Premiums were retrieved successfully");
            return Unit.Value;
        }
    }
}
