using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace Finance.Client.Pages
{
	public class DisplayTableIncomeBase : ComponentBase
	{
		[Parameter]
		public IEnumerable<Income> Incomes { get; set; }
	}
}
