using Finance.Core;
using Finance.ViewModel;
using Finance.Wpf.Service.Interface;
using System.Windows;

namespace Finance.Command.IncomeCommand
{
    internal class DeleteAllIncomesCommand : BaseCommand
    {
        private readonly IncomeViewModel _incomeViewModel;
        private readonly IIncomeService _incomeService;
        public DeleteAllIncomesCommand(IncomeViewModel incomeViewModel, IIncomeService IncomeService)
        {
            _incomeService = IncomeService;

            _incomeViewModel = incomeViewModel;
        }

        public override void Execute(object parameter)
        {
            var sad = MessageBox.Show("Уверены что хотите удалить ВСЕ доходы???", "Удаление", MessageBoxButton.YesNo);

            if (sad == MessageBoxResult.Yes)
            {
                _incomeViewModel.Incomes.Clear();
                _incomeService.DeleteAllIncomeAsync();
            }
        }
       
    }
}
