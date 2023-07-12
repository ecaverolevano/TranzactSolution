using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.Features.Premium.Command.PremiumCreateCommand
{
    public class PremiumCreateCommandRequest : IRequest<Unit>
    {
        public PremiumData premiumData { get; set; }
    }
}
