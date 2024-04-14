using Finance.Application.DTOs;
using Finance.Client.Services.Interface;
using Finance.Domain.Entities;
using Finance.Domain.Model;
using System.Net.Http.Json;
using System.Text;
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
		public async Task<IEnumerable<IncomeDTO>?> GetIncomesAsync()
		{
			try
			{
				var incomes = await _httpClient.GetFromJsonAsync<IEnumerable<IncomeDTO>>("api/Income");
				return incomes;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error" + ex.Message);
				throw ex;
			}
			
		}

        public async Task<CreateIncomeDto> AddIncomeAsync(CreateIncomeDto newIncome)
		{
			try
			 {
				var itemJson = new StringContent(JsonSerializer.Serialize(newIncome), Encoding.UTF8, "application/json");
				var response = await _httpClient.PostAsync($"api/Income/", itemJson);

				if (response.IsSuccessStatusCode)
				{
					var responseBody = await response.Content.ReadAsStreamAsync();

					var addIncome = await JsonSerializer.DeserializeAsync<CreateIncomeDto>(responseBody, new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});

					return addIncome;
				}
				return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error" + ex.Message);
				throw ex;
			}
		}

		public async Task<IEnumerable<CategorySummary>?> GetCat(string selectedCurrency)
		{
			try
			{
				if(String.IsNullOrWhiteSpace(selectedCurrency))
					return null;
				var cat = await _httpClient.GetFromJsonAsync<IEnumerable<CategorySummary>>($"api/Income/Cat/{selectedCurrency}");
				return cat;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error" + ex.Message); throw ex;
			}
		}
	}
}
