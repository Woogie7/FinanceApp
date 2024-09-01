using Finance.Application.Features.IncomeFeatures.Queries;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Finance.Application.Features.IncomeFeatures.Handler;

public class GetAllIncomeHandler : IRequestHandler<GetAllIncomeQuery, IEnumerable<Income>>
{
    private readonly IIncomeRepository _incomeRepository;
    private readonly ILogger<GetAllIncomeHandler> _logger;

    public GetAllIncomeHandler(IIncomeRepository IncomeRepository, ILogger<GetAllIncomeHandler> logger)
    {
        _incomeRepository = IncomeRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Income>> Handle(GetAllIncomeQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Start get all incomes");

            var incomes = await _incomeRepository.GetIncomeByUserIdAsync(request.UserId);
=

            _logger.LogInformation($"Successfully retrieved {incomes.Count()} incomes");

            return incomes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get all incomes");
            return null;
        }
    }
}
