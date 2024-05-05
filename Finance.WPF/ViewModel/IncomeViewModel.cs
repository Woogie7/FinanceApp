using Finance.Application.DTOs;
using Finance.Command.AsyncCommand;
using Finance.Command.IncomeCommand;
using Finance.Core;
using Finance.Domain.Entities;
using Finance.Wpf.Service.Interface;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Finance.ViewModel
{
    class IncomeViewModel : ObservaleObject
	{
		private readonly IIncomeService _incomeService;
		private readonly ICurrencyService _currencyService;
		private readonly ICategoryIncomeService _categoryIncomeService;

		public ObservableCollection<IncomeDTO> Incomes { get; set; }
		public ObservableCollection<Currency> Currencies { get; set; }
		public ObservableCollection<CategoryIncome> Categories { get; set; }


		#region Хуета

		private string id;
		private string amount;
		private DateTime selectedDate = DateTime.Now;
		private IncomeDTO selectedIncome;
		private CategoryIncome selectedCategory;
		private Currency selectedCurrency;
		public string Id
		{
			get { return id; }
			set
			{
				id = value;
				OnPropertyChanged(nameof(Id));
			}
		}

		public string Amount
		{
			get { return amount; }
			set
			{
				amount = value;
				OnPropertyChanged(nameof(Amount));
			}
		}

		public DateTime SelectedDate
		{
			get { return selectedDate.ToUniversalTime(); }
			set
			{
				selectedDate = value;
				OnPropertyChanged(nameof(SelectedDate));
			}
		}
		public Currency SelectedCurrency
		{
			get { return selectedCurrency; }
			set
			{
				selectedCurrency = value;
				OnPropertyChanged(nameof(SelectedCurrency));
			}
		}

		public CategoryIncome SelectedCategory
		{
			get { return selectedCategory; }
			set
			{
				selectedCategory = value;
				OnPropertyChanged(nameof(SelectedCategory));
			}
		}

		public IncomeDTO SelectedIncome
		{
			get { return selectedIncome; }
			set
			{
				selectedIncome = value;
				OnPropertyChanged(nameof(SelectedIncome));
			}
		}

		#endregion

		public ICommand SaveIncomeCommand { get; }
		public ICommand DeleteIncomeCommand { get; }
		public ICommand DeleteAllIncomesCommand { get; }


		public IncomeViewModel(IIncomeService incomeService, ICurrencyService currencyService, ICategoryIncomeService categoryIncomeService)
		{
			_incomeService = incomeService;
			_currencyService = currencyService;
			_categoryIncomeService = categoryIncomeService;

			Incomes = new ObservableCollection<IncomeDTO>();
			Currencies = new ObservableCollection<Currency>();
			Categories = new ObservableCollection<CategoryIncome>();
				
			LoadCurrency(); 
			LoadIncomes();
			LoadCategoryIncome();

            SaveIncomeCommand = new SaveIncomeAsyncCommand(this, _incomeService);
			DeleteIncomeCommand = new DeleteIncomeCommand(this, _incomeService);
			DeleteAllIncomesCommand = new DeleteAllIncomesCommand(this, _incomeService);
		}

		public async Task LoadIncomes()
		{
			Incomes.Clear();
            var allIncome = await _incomeService.GetIncomesAsync();

			foreach (var income in allIncome)
			{
				Incomes.Add(income);
			}
		}
		private async Task LoadCurrency()
		{
			var allCurrencies = await _currencyService.GetCurrenciesAsync();

			foreach (var currency in allCurrencies)
			{
				Currencies.Add(currency);
			}
		}
		private async Task LoadCategoryIncome()
		{
			var allCategoryIncome = await _categoryIncomeService.GetCategoryIncomeAsync();

			foreach (var categoryIncome in allCategoryIncome)
			{
				Categories.Add(categoryIncome);
			}
		}


	}
}
