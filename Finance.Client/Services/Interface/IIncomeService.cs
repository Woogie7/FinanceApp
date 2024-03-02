using Finance.Client.Model;

namespace Finance.Client.Services.Interface
{
	public interface IIncomeService
	{
		Task<IEnumerable<Income>> GetIncomesAsync();
	}
}
