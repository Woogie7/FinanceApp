using Finance.Application.DTOs;
using Finance.Application.DTOs.Income;
using Finance.Domain.Entities;
using Finance.Domain.Model;

namespace Finance.Client.Services.Interface
{
    public interface IIncomeService
	{
		Task<IEnumerable<IncomeDTO>> GetIncomesAsync();
		Task<IEnumerable<CategorySummary>> GetCat(string selectedCurrency);
		Task<CreateIncomeDto> AddIncomeAsync(CreateIncomeDto newIncome);
	}
}
