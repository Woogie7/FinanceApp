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
        public IncomeRepository(FinanceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Income> AddAsync(Income newIncome)
        {
            await _dbContext.Set<Income>().AddAsync(newIncome);
            await _dbContext.SaveChangesAsync();
            return newIncome;
        }

        public Task UpdateAsync(Income income)
        {
            Income exist = _dbContext.Set<Income>().Find(income.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(income);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Income income)
        {
            _dbContext.Set<Income>().Remove(income);
            return Task.CompletedTask;
        }

        public async Task<List<Income>> GetAllAsync()
        {
            return await _dbContext.Set<Income>()
                .AsNoTracking()
                .Include(p=> p.Currency)
                .Include(p=> p.Category)
                .ToListAsync();
        }

        public async Task<Income> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Income>().FindAsync(id);
        }
    }
}
