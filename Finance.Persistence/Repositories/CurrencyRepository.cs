using Finance.Application.Interface.Cache;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
        {
            private readonly FinanceDBContext _dbContext;
            private readonly ICacheService _cacheService;
            public CurrencyRepository(FinanceDBContext dbContext, ICacheService cacheService)
            {
                _dbContext = dbContext;
                _cacheService = cacheService;
            }
            public async Task<Currency> AddAsync(Currency newCurrency)
            {
                try
                {
                    await _dbContext.Currencies.AddAsync(newCurrency);

                    var experetyTime = DateTimeOffset.Now.AddSeconds(10);
                    await _cacheService.SetAsync($"curency{newCurrency.Id}", newCurrency, experetyTime);

                    await _dbContext.SaveChangesAsync();
                    return newCurrency;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }

            public async Task DeleteAsync(int id)
            {
                var deletedIndome = _dbContext.Incomes.FirstOrDefault(i => i.Id == id);
            
                await _cacheService.RemoveAsync($"income{id}");
            
                _dbContext.Incomes.Remove(deletedIndome);
                await _dbContext.SaveChangesAsync();
            }

            public async Task<IEnumerable<Currency>> GetAllAsync()
            {
                return await _cacheService.GetAsync<IEnumerable<Currency>>(
                    $"currencies",
                    async () =>
                    {
                        IEnumerable<Currency> curencies = await _dbContext.Currencies
                            .AsNoTracking()
                            .ToListAsync();

                        return curencies;
                    },
                    DateTimeOffset.Now.AddSeconds(60)
                    );
            }

        public Task UpdateAsync(Currency entity)
        {
            throw new NotImplementedException();
        }
    }
}
