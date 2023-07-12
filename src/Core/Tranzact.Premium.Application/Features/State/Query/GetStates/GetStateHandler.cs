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

namespace Tranzact.Premium.Application.Features.State.Query.GetStates
{
    public class GetStateHandler : IRequestHandler<GetStateQuery, List<GetStateDto>>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetStateHandler> _logger;

        public GetStateHandler(IStateRepository stateRepository, IMapper mapper, IAppLogger<GetStateHandler> logger)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<GetStateDto>> Handle(GetStateQuery request, CancellationToken cancellationToken)
        {
            var List = await _stateRepository.GetAsync();
            var finalData = _mapper.Map<List<GetStateDto>>(List);

            _logger.LogInformation("States were retrieved successfully");
            return finalData;
        }
    }
}
