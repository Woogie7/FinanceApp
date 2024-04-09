using Finance.Application.Features.IncomeFeatures.Queries;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using MediatR;

namespace Finance.Application.Features.IncomeFeatures.Handler;

public class GetAllIncomeHandler : IRequestHandler<GetAllIncomeQuery, List<Income>>
{
    private readonly IIncomeRepository _incomeRepository;

    public GetAllIncomeHandler(IIncomeRepository IncomeRepository)
    {
        _incomeRepository = IncomeRepository;
    }

    public async Task<List<Income>> Handle(GetAllIncomeQuery request, CancellationToken cancellationToken)
    {
        return await _incomeRepository.GetAllAsync();
    }
}
