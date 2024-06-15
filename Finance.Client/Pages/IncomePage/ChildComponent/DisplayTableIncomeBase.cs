using Microsoft.AspNetCore.Components;
using Finance.Domain.Entities;
using Finance.Client.Services;
using Finance.Domain.Model;
using Finance.Application.DTOs.Income;

namespace Finance.Client.Pages.IncomePage.ChildComponent;

public class DisplayTableIncomeBase : ComponentBase
{
    [Parameter]
    public IEnumerable<IncomeDTO> Incomes { get; set; }
}
