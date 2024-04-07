using Finance.Client.Services.Interface;
using Finance.Domain.Model;
using Microsoft.AspNetCore.Components;

namespace Finance.Client.Pages.PageIncome.ChildComponent;

public class SummaryCategoryBase : ComponentBase
{
	[Parameter]
	public bool ShowCategory { get; set; }


	[Inject]
	public IIncomeService CategoryIncomeService { get; set; }

	public IEnumerable<CategorySummary> CategoryIncome { get; set; }

	protected override async Task OnInitializedAsync()
	{
		//CategoryIncome = await CategoryIncomeService.GetCat();
	}
}
