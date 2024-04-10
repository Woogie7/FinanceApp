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

            var income = await _incomeRepository.GetAllAsync();

            _logger.LogInformation("Succeseful");

            return income;
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Not Found {ex.Message}");
            return null;
        }
    }
}
