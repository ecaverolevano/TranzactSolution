using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tranzact.Premium.Application.Features.Plan.Query.GetPlans;
using Tranzact.Premium.Application.Features.Premium.Command.CalcPremium;
using Tranzact.Premium.Application.Features.Premium.Command.PremiumCreateCommand;
using Tranzact.Premium.Application.Features.Premium.Command.PremiumDeleteCommand;
using Tranzact.Premium.Application.Features.Premium.Command.PremiumUpdateCommand;
using Tranzact.Premium.Application.Features.Premium.Query.GetPremiumByIdWithPlans;
using Tranzact.Premium.Application.Features.Premium.Query.GetPremiums;
using Tranzact.Premium.Application.Features.Premium.Shared;

namespace Tranzact.Premium.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PremiumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PremiumController>
        [HttpGet]
        public async Task<List<GetPremiumDto>> Get()
        {
            var data = await _mediator.Send(new GetPremiumQuery());
            return data;
        }

        // GET: api/<PremiumController>/id
        [HttpGet("{id}")]
        public async Task<GetPremiumDto> GetPremiumByIdWithPlans(int id)
        {
            var data = await _mediator.Send(new GetPremiumByIdWithPlansQuery { id = id });
            return data;
        }

        [HttpPost]
        public async Task<ActionResult<List<GetPremiumDto>>> CalcPremium(CalcPremiumCommand calcCommand)
        {
            var response = await _mediator.Send(calcCommand);

            return Ok(response);
        }

        // POST api/<PremiumController>
        [HttpPost("CreatePremium")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreatePremium(PremiumCreateCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok();
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdatePremium(PremiumUpdateCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok();
        }

        // DELETE api/<PremiumController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new PremiumDeleteCommandRequest { id = id });
            return NoContent();
        }
    }
}
