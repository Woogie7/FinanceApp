using GameStore.Domain.Entities;

namespace Finance.Client.Services.Interface
{
	public interface ICurrencyService
	{
		public Task<IEnumerable<Currency>> GetCurrenciesAsync();
	}
}
