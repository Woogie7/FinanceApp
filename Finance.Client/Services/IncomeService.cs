﻿using Finance.Client.Services.Interface;
using GameStore.Domain.Entities;
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
	}
}
