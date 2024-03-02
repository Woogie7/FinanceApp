using GameStore.Domain.Entities;

namespace Finance.Client.Services.Interface
{
	public interface IIncomeService
	{
		Task<IEnumerable<Income>> GetIncomesAsync();
	}
}
