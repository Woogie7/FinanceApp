using Finance.Client.Services.Interface;
using Finance.Domain.Entities;
using System.Net.Http.Json;

namespace Finance.Client.Services
{
	public class CurrencyService : ICurrencyService
	{

		private readonly HttpClient _httpClient;

		public CurrencyService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<Currency>?> GetCurrenciesAsync()
		{
			try
			{
				var currencies = await _httpClient.GetFromJsonAsync<IEnumerable<Currency>>("api/Currency");
				return currencies;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error" + ex.Message);
				throw ex;
			}

		}
	}
}
