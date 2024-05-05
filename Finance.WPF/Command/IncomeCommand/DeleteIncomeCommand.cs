using Finance.Application.DTOs;
using Finance.Core;
using Finance.Domain.Entities;
using Finance.ViewModel;
using Finance.Wpf.Service.Interface;
using System.Collections.Generic;

namespace Finance.Command.IncomeCommand
{
    class DeleteIncomeCommand : BaseCommand
    {
        private readonly IncomeViewModel _incomeViewModel;
        private readonly IIncomeService _incomeService;

        public DeleteIncomeCommand(IncomeViewModel incomeViewModel, IIncomeService incomeService)
        {
            _incomeService = incomeService;

            _incomeViewModel = incomeViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return _incomeViewModel.SelectedIncome != null;
        }
        public override void Execute(object parameter)
        {
            if (parameter is IncomeDTO incomeToDelete)
            {
                _incomeViewModel.Incomes.Remove(incomeToDelete);
                _incomeService.DeleteIncomeAsync(incomeToDelete.ID);
            }
        }
    }
}
