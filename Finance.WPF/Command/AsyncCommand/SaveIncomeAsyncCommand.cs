using Finance.Application.DTOs;
using Finance.Core;
using Finance.ViewModel;
using Finance.Wpf.Service.Interface;
using System;
using System.Threading.Tasks;

namespace Finance.Command.AsyncCommand
{
    class SaveIncomeAsyncCommand : AsyncCommandBase
	{
		private readonly IncomeViewModel _incomeViewModel;
		private readonly IIncomeService _incomeService;

		public SaveIncomeAsyncCommand(IncomeViewModel incomeViewModel, IIncomeService IncomeService)
		{
			_incomeService = IncomeService;

			_incomeViewModel = incomeViewModel;
		}
		public override async Task ExecuteAsync(object parameter)
		{

			CreateIncomeDto newIncome = new CreateIncomeDto()
			{
				Amount = decimal.Parse(_incomeViewModel.Amount),
				CurrencyId = _incomeViewModel.SelectedCurrency.Id,
				Date = DateOnly.FromDateTime(_incomeViewModel.SelectedDate),
				CategoryIncomeId = _incomeViewModel.SelectedCategory.Id
			};

			await _incomeService.AddIncomeAsync(newIncome);

			_incomeViewModel.LoadIncomes();

			_incomeViewModel.Amount = string.Empty;
			_incomeViewModel.SelectedCurrency = null;
			_incomeViewModel.SelectedDate = DateTime.Now;
			_incomeViewModel.SelectedCategory = null;
		}
	}
}
