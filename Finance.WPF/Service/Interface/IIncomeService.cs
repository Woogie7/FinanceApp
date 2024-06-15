using Finance.Application.DTOs;
using Finance.Application.DTOs.Income;
using Finance.Domain.Entities;
using Finance.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finance.Wpf.Service.Interface
{
    public interface IIncomeService
    {
        Task<IEnumerable<IncomeDTO>> GetIncomesAsync();
        Task<IEnumerable<CategorySummary>> GetCat(string selectedCurrency);
        Task<CreateIncomeDto> AddIncomeAsync(CreateIncomeDto newIncome);
        Task<bool> DeleteIncomeAsync(int id);
        Task<bool> DeleteAllIncomeAsync();
    }
}
