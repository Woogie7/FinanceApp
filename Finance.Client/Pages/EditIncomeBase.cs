using Finance.Client.Services.Interface;
using Finance.Domain.Entities;
using Finance.Domain.Model;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Finance.Client.Pages
{
	public class EditIncomeBase : ComponentBase
	{
		[Inject]
		public IIncomeService IncomeService { get; set; }

		public IEnumerable<Currency> Currencies { get; set; }
		public IEnumerable<CategoryIncome> CategoryIncome { get; set; }
		[Inject]
		public ICurrencyService CurrencyService { get; set; }
		[Inject]
		public ICategoryIncomeService CategoryIncomeService
		{
			get; set;
		}
			[Inject]
		public NavigationManager NavigationManager { get; set; }

		public Income newIncome = new Income();

		public int selectedCurrencyId;
		public int selectedCategoryId;

		protected override async Task OnInitializedAsync()
		{
			Currencies = await CurrencyService.GetCurrenciesAsync();
			CategoryIncome = await CategoryIncomeService.GetCategoryIncomeAsync();
		}

		public async void HandleSubmit()
		{
			await IncomeService.AddIncomeAsync(newIncome);
			NavigationManager.NavigateTo("/");
		}

		public void HandleCancel()
		{
			NavigationManager.NavigateTo("/");
		}
	}
}
