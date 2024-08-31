using Finance.Application.Interface.Cache;
using Finance.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.IncomeFeatures.Command
{
    public record DeleteIncomeCommand(int id) : IRequest<bool>, ICacheInvalidatingCommand<bool>
    {
        public IEnumerable<string> GetCacheKeysToInvalidate()
        {
            return new List<string> { "incomes" };
        }
    }
}
