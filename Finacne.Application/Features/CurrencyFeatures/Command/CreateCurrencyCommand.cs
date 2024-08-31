using Finance.Application.Interface.Cache;
using Finance.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.CurrencyFeatures.Command;

public record CreateCurrencyCommand(Currency newCurrency) : IRequest<Currency>, ICacheInvalidatingCommand<Currency>
{
    public IEnumerable<string> GetCacheKeysToInvalidate()
    {
        return new List<string> { "currencies" };
    }
}
