using Finance.Application.DTOs;
using Finance.Application.Interface.Cache;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using Finance.Domain.Entities.Users;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly FinanceDBContext _dbContext;
        private readonly ICacheService _cacheService;
        public IncomeRepository(FinanceDBContext dbContext, ICacheService cacheService)
        {
            _dbContext = dbContext;
            _cacheService = cacheService;
        }
            public async Task<Income> AddAsync(Income newIncome)
            {
                try
                {
                    var category = await _dbContext.CategoryIncomes.FirstOrDefaultAsync(c => c.Id == newIncome.CategoryIncomeId);
                    var currency = await _dbContext.Currencies.FirstOrDefaultAsync(c => c.Id == newIncome.CurrencyId);
                    var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == newIncome.UserId);

                    newIncome.Currency = currency;
                    newIncome.Category = category;
                    newIncome.User = user;

                    await _dbContext.Incomes.AddAsync(newIncome);

                    var experetyTime = DateTimeOffset.Now.AddSeconds(60);
                    await _cacheService.SetAsync($"income{newIncome.Id}", newIncome, experetyTime);

                    return newIncome;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }

        public async Task UpdateAsync(Income income)
        {
            var existingIncome = await _dbContext.Incomes.FirstOrDefaultAsync(i => i.Id == income.Id);

            if (existingIncome == null)
            {
                return;
            }

            existingIncome.Amount = income.Amount;
            existingIncome.Currency = income.Currency;
            existingIncome.Date = income.Date;
            existingIncome.CategoryIncomeId = income.CategoryIncomeId;
            existingIncome.CurrencyId = income.CurrencyId;
            existingIncome.Category = income.Category;

            await _dbContext.SaveChangesAsync();

            var cacheKey = $"income{income.Id}";
            await _cacheService.SetAsync(cacheKey, existingIncome, DateTimeOffset.Now.AddSeconds(60));

            await _cacheService.RemoveAsync("incomes");
        }

        public async Task DeleteAsync(int id)
        {
            var deletedIndome = _dbContext.Incomes.FirstOrDefault(i => i.Id == id);
            await _cacheService.RemoveAsync($"income{id}");
            _dbContext.Incomes.Remove(deletedIndome);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Income>> GetAllAsync()
        {
            return await _cacheService.GetAsync<IEnumerable<Income>>(
                $"incomes",
                async () =>
                {
                    IEnumerable<Income> incomes = await _dbContext.Incomes
                        .AsNoTracking()
                        .Include(x => x.Category)
                        .Include(x => x.Currency)
                        .ToListAsync();

                    return incomes;
                },
                DateTimeOffset.Now.AddSeconds(60)
                );
        }

        public async Task<Income> GetByIdAsync(int id)
        {
            return await _cacheService.GetAsync<Income>(
                $"income{id}",
                async () =>
                {
                    Income income = await _dbContext.Incomes
                        .Include(i => i.Currency)
                        .Include(i => i.Category)
                        .FirstOrDefaultAsync(x => x.Id == id);

                    return income;
                },
                DateTimeOffset.Now.AddSeconds(20)
                );
        }

        public async Task DeleteAllAsync()
        {
            var allIncomes = _dbContext.Incomes.ToList();
            _dbContext.Incomes.RemoveRange(allIncomes);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Income>> GetIncomeByUserIdAsync(Guid userId)
        {
            return await _cacheService.GetAsync<IEnumerable<Income>>(
                $"incomes:userid-{userId}",
                async () =>
                {
                    IEnumerable<Income> income = await _dbContext.Incomes
                        .Include(i => i.Currency)
                        .Include(i => i.Category)
                        .Include(i => i.User)
                         .Where(i => i.UserId == userId)
                        .ToListAsync();

                    return income;
                },
                DateTimeOffset.Now.AddMinutes(10)
                );
        }
    }
}
