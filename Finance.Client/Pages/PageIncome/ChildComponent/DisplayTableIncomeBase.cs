using Microsoft.AspNetCore.Components;
using Finance.Domain.Entities;

namespace Finance.Client.Pages.PageIncome
{
    public class DisplayTableIncomeBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<Income> Incomes { get; set; }
    }
}
