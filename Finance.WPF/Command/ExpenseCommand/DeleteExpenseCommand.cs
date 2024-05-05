using Finance.ViewModel;
using System.Collections.Generic;
using Finance.Core;

namespace Finance.Command.ExpenseCommand
{
    internal class DeleteExpenseCommand : BaseCommand
    {
        //private readonly ExpanseViewModel _expanseViewModel;
        //private readonly IExpеnseService _expanseService;

        //public DeleteExpenseCommand(ExpanseViewModel expanseViewModel, IExpеnseService expеnseService)
        //{
        //	_expanseService = expеnseService;

        //	_expanseViewModel = expanseViewModel;
        //}

        //public override bool CanExecute(object parameter)
        //{
        //	return _expanseViewModel.SelectedExpense != null;
        //}
        //public override void Execute(object parameter)
        //{
        //	if (parameter is Expense expenseToDelete)
        //	{
        //		_expanseViewModel.Expenses.Remove(expenseToDelete);
        //		_expanseService.Delete(expenseToDelete.Id);
        //	}
        //}
        public override void Execute(object parameter)
        {
            throw new System.NotImplementedException();
        }
    }
}
