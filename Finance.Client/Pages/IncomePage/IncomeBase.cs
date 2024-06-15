using Finance.Client.Services.Interface;
using Microsoft.AspNetCore.Components;
using Finance.Domain.Entities;
using Radzen;
using Finance.Application.DTOs.Income;

namespace Finance.Client.Pages.IncomePage;

public class IncomeBase : ComponentBase
{
    [Inject]
    public IIncomeService IncomeService { get; set; }
    [Inject]
    public ICurrencyService CurrencyService { get; set; }
    [Inject]
    public NavigationManager NavigationManager { get; set; }


    public IEnumerable<IncomeDTO> Incomes { get; set; }
    public IEnumerable<IncomeDTO> FilterIncomes { get; set; }
    public IEnumerable<Currency> Currencies { get; set; }

    public string SelectedCurrency;
    public string SelectedCategory;
    public bool ShowCategory { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Incomes = await IncomeService.GetIncomesAsync();
        Currencies = await CurrencyService.GetCurrenciesAsync();

        FilterIncomes = Incomes;
    }

    public void HandleSumbit()
    {
        NavigationManager.NavigateTo("/EditIncome");
    }

    public void ChangeCurrency(ChangeEventArgs e)
    {
        SelectedCurrency = e.Value.ToString();
        ShowCategory = false;
        SelectedCategory = null;
        FilteredIncomes();

        StateHasChanged();
    }

    private void FilteredIncomes()
    {
        if (string.IsNullOrWhiteSpace(SelectedCurrency) && string.IsNullOrWhiteSpace(SelectedCategory))
        {
            FilterIncomes = Incomes;
        }
        else
        {
            ShowCategory = true;
            FilterIncomes = Incomes.Where(i => i.Currency == SelectedCurrency && (string.IsNullOrEmpty(SelectedCategory) || i.CategoryIncome == SelectedCategory));


        }
    }
    public void HandleCategoryClicked(string selectedCategory)
    {
        if (SelectedCategory != selectedCategory)
        {
            SelectedCategory = selectedCategory;
            FilteredIncomes();
        }
        else
        {
            SelectedCategory = null;
        }
    }

}
