﻿using Finance.Application.DTOs;
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
            try
            {
                var category = await _dbContext.CategoryIncomes.FirstOrDefaultAsync(c => c.Id == newIncome.CategoryIncomeId);
                var currency = await _dbContext.Currencies.FirstOrDefaultAsync(c => c.Id == newIncome.CurrencyId);

                newIncome.Currency = currency;
                newIncome.Category = category;

                await _dbContext.Incomes.AddAsync(newIncome);
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
            return await _dbContext.Incomes
                .Include(x => x.Category)
                .Include(x => x.Currency)
                .ToListAsync();
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
