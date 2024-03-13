using Finance.Client.Services.Interface;
using Finance.Domain.DTOs.Income;
using Finance.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace Finance.Client.Pages
{
	public class EditIncomeBase : ComponentBase
	{
		public Finance.Domain.Entities.Income Income { get; set; } = new Domain.Entities.Income();

		public IEnumerable<Currency> Currencies { get; set; }
		public IEnumerable<CategoryIncome> CategoryIncomes { get; set; }
	}
}
