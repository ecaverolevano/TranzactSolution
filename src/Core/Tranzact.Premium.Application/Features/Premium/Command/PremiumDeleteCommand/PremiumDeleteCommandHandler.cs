using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Application.Contracts.Logging;
using Tranzact.Premium.Application.Contracts.Persistence;
using Tranzact.Premium.Application.Exceptions;
using Tranzact.Premium.Application.Features.Premium.Command.PremiumCreateCommand;

namespace Tranzact.Premium.Application.Features.Premium.Command.PremiumDeleteCommand
{
    public class PremiumDeleteCommandHandler : IRequestHandler<PremiumDeleteCommandRequest, Unit>
    {
        private readonly IPremiumRepository _premiumRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<PremiumCreateCommandHandler> _logger;

        public PremiumDeleteCommandHandler(IPremiumRepository premiumRepository, IMapper mapper, IAppLogger<PremiumCreateCommandHandler> logger)
        {
            _premiumRepository = premiumRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(PremiumDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _premiumRepository.GetByIdAsync(request.id);

            if (data == null)
                throw new NotFoundException(nameof(data), request.id);

            await _premiumRepository.DeleteAsync(data);
            return Unit.Value;
        }
    }
}
