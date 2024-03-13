using Finance.Domain.DTOs.Income;
using Microsoft.AspNetCore.Components;

namespace Finance.Client.Pages.Income.ChildComponent
{
    public class DisplayTableIncomeBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<IncomeDTO> Incomes { get; set; }
    }
}
