using Microsoft.AspNetCore.Components;
using Finance.Domain.Entities;
using Finance.Application.DTOs;

namespace Finance.Client.Pages.PageIncome
{
    public class DisplayTableIncomeBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<IncomeDTO> Incomes { get; set; }
    }
}
