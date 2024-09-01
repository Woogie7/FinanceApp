
using Finance.Domain.Entities;
using MediatR;

namespace Finance.Application.Features.IncomeFeatures.Queries;

public record GetAllIncomeQuery : IRequest<IEnumerable<Income>>
{
    public Guid UserId { get; }

    public GetAllIncomeQuery(Guid userId)
    {
        UserId = userId;
    }
}
