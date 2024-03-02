using Finance.Client.Model;
using Finance.Client.Services.Interface;
using System.Net.Http.Json;
using System.Text.Json;

namespace Finance.Client.Services
{
	public class IncomeService : IIncomeService
	{
		private readonly HttpClient _httpClient;

		public IncomeService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IEnumerable<Income>?> GetIncomesAsync()
		{
			try
			{
				var apiResponse = await _httpClient.GetStreamAsync("api/income");
				var incomes = await JsonSerializer.DeserializeAsync<IEnumerable<Income>>(apiResponse, new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});
				return incomes;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error" + ex.Message);
				throw ex;
			}
			
		}
	}
}
