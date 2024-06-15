using Finance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Interface.Repositories
{
    public interface IExpenseRepository
    {
        Task<Income> GetByIdAsync(int id);
        Task<IEnumerable<Expense>> GetAllAsync();
        Task<Expense> AddAsync(Expense newExpense);
        Task UpdateAsync(Income entity);
        Task DeleteAsync(int id);
        Task DeleteAllAsync();
    }
}
