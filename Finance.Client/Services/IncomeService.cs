using Finance.Client.Services.Interface;
using Finance.Domain.Entities;
using Finance.Domain.Model;
using System.Net.Http.Json;

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
				var incomes = await _httpClient.GetFromJsonAsync<IEnumerable<Income>>("api/Income");
				return incomes;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error" + ex.Message);
				throw ex;
			}
			
		}

		//public async Task<Income> AddIncomeAsync(CreateIncomeDTO newIncome)
		//{
		//	try
		//	{
		//		var itemJson = new StringContent(JsonSerializer.Serialize(newIncome), Encoding.UTF8, "application/json");
		//		var response = await _httpClient.PostAsync($"api/Income/", itemJson);

		//		if(response.IsSuccessStatusCode)
		//		{
		//			var responseBody = await response.Content.ReadAsStreamAsync();

		//			var addIncome = await JsonSerializer.DeserializeAsync<Income>(responseBody, new JsonSerializerOptions
		//			{
		//				PropertyNameCaseInsensitive = true
		//			});

		//			return addIncome;
		//		}
		//		return null;
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine("Error" + ex.Message);
		//		throw ex;
		//	}
		//}

		public async Task<IEnumerable<CategorySummary>?> GetCat()
		{
			try
			{
				var cat = await _httpClient.GetFromJsonAsync<IEnumerable<CategorySummary>>("api/Income/cat");
				return cat;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error" + ex.Message); throw ex;
			}
		}
	}
}
