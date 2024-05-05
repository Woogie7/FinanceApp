using Finance.Command;
using Finance.Core;
using Finance.Service.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Finance.ViewModel
{
    class MainWindowViewModel : ObservaleObject
	{
		private readonly NavigationStore _navigationStore;
		public ObservaleObject CurrentViewModel => _navigationStore.CurrentViewModel;

		public ICommand IncomeNavigateCommand { get; }
		public ICommand ExpenseNavigateCommand { get; }
		public ICommand BalanceNavigateCommand { get; }

		public MainWindowViewModel(NavigationStore navigationStore, NavigationService<IncomeViewModel> incomeNavigationService,
			NavigationService<ExpanseViewModel> expanseNavigationService,
			NavigationService<BalanceViewModel> balanceNavigationService
			)
		{
			_navigationStore = navigationStore;

			IncomeNavigateCommand = new NavigateCommand<IncomeViewModel>(incomeNavigationService);
			ExpenseNavigateCommand = new NavigateCommand<ExpanseViewModel>(expanseNavigationService);
			BalanceNavigateCommand = new NavigateCommand<BalanceViewModel>(balanceNavigationService);

			_navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
		}

		private void OnCurrentViewModelChanged()
		{
			OnPropertyChanged(nameof(CurrentViewModel));
		}
	}
}
