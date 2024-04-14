using Finance.Client.Services.Interface;
using Finance.Domain.Model;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace Finance.Client.Pages.PageIncome.ChildComponent;

public class SummaryCategoryBase : ComponentBase
{
	[Parameter]
	public bool ShowCategory { get; set; }
    
	[Parameter]
    public string SelectedCurrency { get; set; }


    [Inject]
	public IIncomeService CategoryIncomeService { get; set; }

	public IEnumerable<CategorySummary> CategorySummary { get; set; }

	public bool showDataLabels = false;

    protected override async Task OnParametersSetAsync()
    {
        await LoadCategorySummary();
    }

    private async Task LoadCategorySummary()
    {
        CategorySummary = await CategoryIncomeService.GetCat(SelectedCurrency);
        StateHasChanged(); // Обновляем компонент после загрузки данных
    }


    [Parameter]
    public EventCallback<string> CategoryClicked { get; set; }

    public void OnSeriesClick(SeriesClickEventArgs args)
    {
        var category = args.Category.ToString();
        CategoryClicked.InvokeAsync(category);
    }


}
