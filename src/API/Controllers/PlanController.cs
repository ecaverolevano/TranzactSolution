using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tranzact.Premium.Application.Features.Carrier.Query.GetCarriers;
using Tranzact.Premium.Application.Features.Plan.Query.GetPlans;

namespace Tranzact.Premium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PlanController>
        [HttpGet]
        public async Task<List<GetPlanDto>> Get()
        {
            var data = await _mediator.Send(new GetPlanQuery());
            return data;
        }
    }
}
