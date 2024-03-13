using Finance.Domain.Model;
using Finance.Client.Services.Interface;
using Finance.Domain.Entities;
using Microsoft.AspNetCore.Components;
using Finance.Domain.DTOs.Income;

namespace Finance.Client.Pages.Income;

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

    private int selectedCurrencyId;

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
        selectedCurrencyId = Convert.ToInt32(e.Value);
        StateHasChanged();
    }

    public IEnumerable<IncomeDTO> FilteredIncomes()
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
}
