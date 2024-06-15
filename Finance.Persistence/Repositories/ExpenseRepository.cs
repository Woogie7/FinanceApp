using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly FinanceDBContext _dbContext;
        private readonly ILogger<ExpenseRepository> _logger;
        public ExpenseRepository(FinanceDBContext dbContext, ILogger<ExpenseRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<Expense> AddAsync(Expense newExpense)
        {
            try
            {
                var category = await _dbContext.CategoryExpenses.FirstOrDefaultAsync(c => c.Id == newExpense.CategoryExpenseId);
                var currency = await _dbContext.Currencies.FirstOrDefaultAsync(c => c.Id == newExpense.CurrencyId);

                newExpense.Currency = currency;
                newExpense.Category = category;

                await _dbContext.Expenses.AddAsync(newExpense);
                await _dbContext.SaveChangesAsync();
                return newExpense;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return null;
            }
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _dbContext.Expenses
                .AsNoTracking()
                .Include(e =>e.Currency)
                .Include(e =>e.Category)
                .ToListAsync();
        }

        public Task<Income> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Income entity)
        {
            throw new NotImplementedException();
        }
    }
}
