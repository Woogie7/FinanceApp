using Finance.Application.DTOs;
using Finance.Client.Services;
using Finance.Client.Services.Interface;
using Finance.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace Finance.Client.Pages
{
    public class EditIncomeBase : ComponentBase
	{
		public CreateIncomeDto NewIncome = new CreateIncomeDto();

        public IEnumerable<Currency> Currencies { get; set; }
		public IEnumerable<CategoryIncome> CategoryIncomes { get; set; }


        [Inject]
        public IIncomeService IncomeService { get; set; }

        [Inject]
        public ICurrencyService CurrencyService { get; set; }
        [Inject]
        public ICategoryIncomeService CategoryIncomeService { get; set; }
        [Inject]
        public ILogger<EditIncomeBase> logger { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Currencies = await CurrencyService.GetCurrenciesAsync();
            CategoryIncomes = await CategoryIncomeService.GetCategoryIncomeAsync();
        }

        public async Task AddIncome()
        {
            await IncomeService.AddIncomeAsync(NewIncome);
        }
    }
}
