using Finance.Application.DTOs;
using Finance.Application.Interface;
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

                newIncome.Currency = currency;
                newIncome.Category = category;

                await _dbContext.Incomes.AddAsync(newIncome);

                var experetyTime = DateTimeOffset.Now.AddSeconds(10);
                _cacheService.SetData($"income{newIncome.Id}", newIncome, experetyTime);

                await _dbContext.SaveChangesAsync();
                return newIncome;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public Task UpdateAsync(Income income)
        {
            var updatedIncome = _dbContext.Incomes.FirstOrDefaultAsync(i => i.Id == income.Id);
            
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var deletedIndome = _dbContext.Incomes.FirstOrDefault(i => i.Id == id);
            _dbContext.Incomes.Remove(deletedIndome);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Income>> GetAllAsync()
        {
            var cacheData = _cacheService.GetData<IEnumerable<Income>>("incomes");

            if(cacheData != null)
                return cacheData;

            cacheData = await _dbContext.Incomes
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.Currency)
                .ToListAsync();

            var experetyTime = DateTimeOffset.Now.AddSeconds(60);
            var isSuccses = _cacheService.SetData($"incomes", cacheData, experetyTime);

            return cacheData;
        }

        public async Task<Income> GetByIdAsync(int id)
        {
            return await _dbContext.Incomes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAllAsync()
        {
            var allIncomes = _dbContext.Incomes.ToList();
            _dbContext.Incomes.RemoveRange(allIncomes);
            await _dbContext.SaveChangesAsync();
        }
    }
}
