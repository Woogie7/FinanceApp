using Finance.Application.DTOs.Income;
using Finance.Application.DTOs;
using Finance.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Application.DTOs.DtoExpense;

namespace Finance.Application.Interface.Api
{
    public interface IExpenseApiService
    {
        Task<IEnumerable<ExpenseDto>> GetExpenseAsync();
        Task<CreateExpenseDto> AddExpenseAsync(CreateExpenseDto newExpense);
    }
}
