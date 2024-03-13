using Finance.Client.Pages;
using Finance.Domain.DTOs.Income;
using Finance.Domain.Entities;
using Finance.Domain.Model;

namespace Finance.Client.Services.Interface
{
	public interface IIncomeService
	{
		Task<IEnumerable<IncomeDTO>> GetIncomesAsync();
		Task<IEnumerable<CategorySummary>> GetCat();
		Task<Income> AddIncomeAsync(CreateIncomeDTO newIncome);
	}
}
