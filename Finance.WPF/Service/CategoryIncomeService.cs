using Finance.Domain.Entities;
using Finance.Wpf.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Wpf.Service
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
