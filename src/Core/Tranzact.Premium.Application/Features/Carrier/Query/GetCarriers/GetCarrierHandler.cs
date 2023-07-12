using AutoMapper;
using MediatR;
using Tranzact.Premium.Application.Contracts.Logging;
using Tranzact.Premium.Application.Contracts.Persistence;

namespace Tranzact.Premium.Application.Features.Carrier.Query.GetCarriers;

public class GetCarrierHandler : IRequestHandler<GetCarrierQuery, List<GetCarrierDto>>
{
    private readonly ICarrierRepository _carrierRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetCarrierHandler> _logger;

    public GetCarrierHandler(ICarrierRepository carrierRepository, IMapper mapper, IAppLogger<GetCarrierHandler> logger)
    {
        _carrierRepository = carrierRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<GetCarrierDto>> Handle(GetCarrierQuery request, CancellationToken cancellationToken)
    {
        var list = await _carrierRepository.GetAsync();
        var finalData = _mapper.Map<List<GetCarrierDto>>(list);

        _logger.LogInformation("Carriers were retrieved successfully");
        return finalData;
    }
}
