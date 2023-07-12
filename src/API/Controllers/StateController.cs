using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tranzact.Premium.Application.Features.Plan.Query.GetPlans;
using Tranzact.Premium.Application.Features.State.Query.GetStates;

namespace Tranzact.Premium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<StateController>
        [HttpGet]
        public async Task<List<GetStateDto>> Get()
        {
            var data = await _mediator.Send(new GetStateQuery());
            return data;
        }
    }
}
