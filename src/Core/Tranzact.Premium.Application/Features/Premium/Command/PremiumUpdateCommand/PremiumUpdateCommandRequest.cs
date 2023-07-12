using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.Features.Premium.Command.PremiumUpdateCommand
{
    public class PremiumUpdateCommandRequest : IRequest<Unit>
    {
        public PremiumData PremiumData { get; set; }
    }
}
