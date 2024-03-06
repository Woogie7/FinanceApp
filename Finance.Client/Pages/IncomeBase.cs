using Finance.Domain.Model;
using Finance.Client.Services.Interface;
using Finance.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace Finance.Client.Pages;

public class IncomeBase : ComponentBase
{
	[Inject]
	public IIncomeService IncomeService {  get; set; }
	[Inject]
	public ICurrencyService CurrencyService {  get; set; }
	
	[Inject]
	public ICategoryIncomeService CategoryIncomeService {  get; set; }
	[Inject]
	public NavigationManager NavigationManager {  get; set; }
	public IEnumerable<Income> Incomes { get; set; }
	public IEnumerable<Currency> Currencies { get; set; }
	public IEnumerable<CategorySummary> CategoryIncome { get; set; }

	protected override async Task OnInitializedAsync()
	{
		Incomes = await IncomeService.GetIncomesAsync();
		Currencies = await CurrencyService.GetCurrenciesAsync();
		CategoryIncome = await IncomeService.GetCat();

	}

	public void HandleSumbit()
	{
		NavigationManager.NavigateTo("/EditIncome");
	}
	private int selectedCurrencyId;

	public void ChangeCurrency(ChangeEventArgs e)
	{
		selectedCurrencyId = Convert.ToInt32(e.Value);
		StateHasChanged();
	}

	public IEnumerable<Income> FilteredIncomes()
	{
		if (selectedCurrencyId == 0)
		{
			return Incomes;
		}
		else
		{
			return Incomes.Where(i => i.CurrencyId == selectedCurrencyId);
		}
	}

	public IEnumerable<CategorySummary> ShowCategory()
	{
		return null;
	}
}
