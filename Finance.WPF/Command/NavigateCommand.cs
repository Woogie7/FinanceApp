using Finance.Core;
using Finance.Service.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Command
{
	internal class NavigateCommand<TViewModel> : BaseCommand where TViewModel : ObservaleObject
	{
		private readonly NavigationService<TViewModel> _navigationService;
		public NavigateCommand(NavigationService<TViewModel> navigationService)
		{
			_navigationService = navigationService;
		}

		public override void Execute(object parameter)
		{
			_navigationService.Navigate();
		}
	}
}
