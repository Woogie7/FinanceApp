using Finance.Client.Services.Interface;
using GameStore.Domain.Entities;
using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace Finance.Client.Pages
{
	public class EditIncomeBase : ComponentBase
	{
		[Inject]
		public IIncomeService IncomeService { get; set; }
		[Inject]
		public NavigationManager NavigationManager { get; set; }

		private Income income = new()
		{
			Amount = 0,
			Category = null,
			Currency = null,
			Date = new DateOnly(2023, 5, 5)
		};

		private void HandleSubmit()
		{
			NavigationManager.NavigateTo("/");
		}

		private void HandleCancel()
		{
			NavigationManager.NavigateTo("/");
		}
	}
}
