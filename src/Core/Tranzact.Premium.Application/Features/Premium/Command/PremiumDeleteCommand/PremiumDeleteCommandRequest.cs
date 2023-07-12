using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Premium.Application.Features.Premium.Command.PremiumDeleteCommand
{
    public class PremiumDeleteCommandRequest : IRequest<Unit>
    {
        public int id { get; set; }
    }
}
