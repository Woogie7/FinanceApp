using Finance.Application.Features.CurrencyFeatures.Queries;
using Finance.Application.Features.IncomeFeatures.Handler;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.CurrencyFeatures.Handler;

public class GetAllCurrencyHeandler : IRequestHandler<GetAllCurrencyQuery, IEnumerable<Currency>>
{
    private readonly ICurrencyRepository _curencyRepository;
    private readonly ILogger<GetAllCurrencyHeandler> _logger;

    public GetAllCurrencyHeandler(ICurrencyRepository CurencyRepository, ILogger<GetAllCurrencyHeandler> logger)
    {
        _curencyRepository = CurencyRepository;
        _logger = logger;
    }
    public async Task<IEnumerable<Currency>> Handle(GetAllCurrencyQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Start get all currencies");

            var currencies = await _curencyRepository.GetAllAsync();

            _logger.LogInformation($"Successfully retrieved {currencies.Count()} currencies");

            return currencies;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get all currencies");
            return null;
        }
    }
}
