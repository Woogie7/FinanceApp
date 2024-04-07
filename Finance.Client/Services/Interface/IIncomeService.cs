using Finance.Domain.Entities;
using Finance.Domain.Model;

namespace Finance.Client.Services.Interface
{
	public interface IIncomeService
	{
		Task<IEnumerable<Income>> GetIncomesAsync();
		Task<IEnumerable<CategorySummary>> GetCat();
		//Task<Income> AddIncomeAsync(CreateIncomeDTO newIncome);
	}
}
