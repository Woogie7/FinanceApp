using GameStore.Domain.Entities;

namespace Finance.Client.Services.Interface
{
	public interface ICategoryIncomeService
	{
		public Task<IEnumerable<CategoryIncome>> GetCategoryIncomeAsync();
	}
}
