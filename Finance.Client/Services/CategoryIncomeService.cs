using Finance.Client.Services.Interface;
using Finance.Domain.Entities;
using System.Net.Http.Json;

namespace Finance.Client.Services
{
	public class CategoryIncomeService : ICategoryIncomeService
	{
		private readonly HttpClient _httpClient;

		public CategoryIncomeService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<CategoryIncome>?> GetCategoryIncomeAsync()
		{
			try
			{
				var categoryIncome = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryIncome>>("api/CategoryIncome");
				return categoryIncome;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error" + ex.Message);
				throw ex;
			}
		}
	}
}
