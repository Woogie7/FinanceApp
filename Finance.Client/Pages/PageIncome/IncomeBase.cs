using Finance.Client.Services.Interface;
using Microsoft.AspNetCore.Components;
using Finance.Domain.Entities;
using Finance.Application.DTOs;

namespace Finance.Client.Pages.PageIncome;

public class IncomeBase : ComponentBase
{
    [Inject]
    public IIncomeService IncomeService { get; set; }
    [Inject]
    public ICurrencyService CurrencyService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }


    public IEnumerable<IncomeDTO> Incomes { get; set; }
    public IEnumerable<Currency> Currencies { get; set; }

    private string selectedCurrency;

    public string Description { get; set; } = string.Empty;
	public bool ShowCategory { get; set; }

	protected override async Task OnInitializedAsync()
    {
        Incomes = await IncomeService.GetIncomesAsync();
        Currencies = await CurrencyService.GetCurrenciesAsync();
    }

    public void HandleSumbit()
    {
        NavigationManager.NavigateTo("/EditIncome");
    }

    public void ChangeCurrency(ChangeEventArgs e)
    {
        selectedCurrency = e.Value.ToString();
        StateHasChanged();
    }

	public IEnumerable<IncomeDTO> FilteredIncomes()
    {
        if (String.IsNullOrWhiteSpace(selectedCurrency))
        {
            return Incomes;
        }
        else
        {
            return Incomes.Where(i => i.Currency == selectedCurrency);
        }
    }
}
