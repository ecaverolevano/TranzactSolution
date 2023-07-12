using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Premium.Application.Features.State.Query.GetStates
{
    public class GetStateQuery : IRequest<List<GetStateDto>>
    {
    }
}
