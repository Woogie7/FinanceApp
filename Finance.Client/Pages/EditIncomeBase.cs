using Finance.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace Finance.Client.Pages
{
	public class EditIncomeBase : ComponentBase
	{
		public Income Income { get; set; } = new Domain.Entities.Income();

		public IEnumerable<Currency> Currencies { get; set; }
		public IEnumerable<CategoryIncome> CategoryIncomes { get; set; }
	}
}
