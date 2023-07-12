using MediatR;
using Tranzact.Premium.Application.Features.Premium.Shared;

namespace Tranzact.Premium.Application.Features.Premium.Query.GetPremiums
{
    public class GetPremiumQuery : IRequest<List<GetPremiumDto>>
    {
    }
}
