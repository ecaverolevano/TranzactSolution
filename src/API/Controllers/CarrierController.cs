using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tranzact.Premium.Application.Features.Carrier.Query.GetCarriers;

namespace Tranzact.Premium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarrierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CarrierController>
        [HttpGet]
        public async Task<List<GetCarrierDto>> Get()
        {
            var data = await _mediator.Send(new GetCarrierQuery());
            return data;
        }
    }
}
