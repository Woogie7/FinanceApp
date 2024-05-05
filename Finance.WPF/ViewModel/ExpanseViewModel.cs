using Finance.Core;

namespace Finance.ViewModel
{
    class ExpanseViewModel : ObservaleObject
	{
		//private readonly IExpеnseService _expеnseService;
		//private readonly ICurrencyService _currencyService;
		//private readonly ICategoryExpenseService _categoryExpenseService;

		//public ObservableCollection<Expense> Expenses { get; set; }

		//public ObservableCollection<Currency> Currencies { get; set; }
		//public ObservableCollection<CategoryExpense> Categories { get; set; }



		//#region Гавно
		//private string id;
		//private string amount;
		//private DateTime selectedDate = DateTime.Today;
		//private Expense selectedExpense;
		//private CategoryExpense selectedCategory;
		//private Currency selectedCurrency;
		//public string Id
		//{
		//	get { return id; }
		//	set
		//	{
		//		id = value;
		//		OnPropertyChanged(nameof(Id));
		//	}
		//}

		//public string Amount
		//{
		//	get { return amount; }
		//	set
		//	{
		//		amount = value;
		//		OnPropertyChanged(nameof(Amount));
		//	}
		//}
		//private string selectedBalanceCurrency;
		//public string SelectedBalanceCurrency
		//{
		//	get { return selectedBalanceCurrency; }
		//	set
		//	{
		//		selectedBalanceCurrency = value;
		//		OnPropertyChanged(nameof(SelectedBalanceCurrency));
		//	}
		//}
		//public DateTime SelectedDate
		//{
		//	get { return selectedDate.ToUniversalTime(); }
		//	set
		//	{
		//		selectedDate = value;
		//		OnPropertyChanged(nameof(SelectedDate));
		//	}
		//}

		//public CategoryExpense SelectedCategory
		//{
		//	get { return selectedCategory; }
		//	set
		//	{
		//		selectedCategory = value;
		//		OnPropertyChanged(nameof(SelectedCategory));
		//	}
		//}


		//public Currency SelectedCurrency
		//{
		//	get { return selectedCurrency; }
		//	set
		//	{
		//		selectedCurrency = value;
		//		OnPropertyChanged(nameof(SelectedCurrency));
		//	}
		//}
		//public Expense SelectedExpense
		//{
		//	get { return selectedExpense; }
		//	set
		//	{
		//		selectedExpense = value;
		//		OnPropertyChanged(nameof(SelectedExpense));
		//	}
		//}

		//#endregion
		//public ICommand SaveExpenseCommand { get; }
		//public ICommand DeleteExpenseCommand { get; }
		//public ICommand DeleteAllExpensesCommand { get; }

		//public ExpanseViewModel(IExpеnseService expеnseService, ICurrencyService currencyService, ICategoryExpenseService categoryExpenseService)
		//{
		//	_expеnseService = expеnseService;
		//	_currencyService = currencyService;
		//	_categoryExpenseService = categoryExpenseService;

		//	Expenses = new ObservableCollection<Expense>();
		//	Currencies = new ObservableCollection<Currency>();
		//	Categories = new ObservableCollection<CategoryExpense>();

		//	LoadExpenses();
		//	LoadCurrency();
		//	LoadCategoryExpense();

		//	SaveExpenseCommand = new SaveExpenseCommand(this, _expеnseService);
		//	DeleteExpenseCommand = new DeleteExpenseCommand(this, _expеnseService);
		//	DeleteAllExpensesCommand = new DeleteAllExpensesCommand(this, _expеnseService);
		//}

		//private async void LoadExpenses()
		//{
		//	var allExpense = await _expеnseService.GetAll();

		//	foreach (var income in allExpense)
		//	{
		//		Expenses.Add(income);
		//	}
		//}
		//private async void LoadCurrency()
		//{
		//	var allCurrencies = await _currencyService.GetAll();

		//	foreach (var currency in allCurrencies)
		//	{
		//		Currencies.Add(currency);
		//	}
		//}
		//private async void LoadCategoryExpense()
		//{
		//	var allCategoryExpense = await _categoryExpenseService.GetAll();

		//	foreach (var categoryIncome in allCategoryExpense)
		//	{
		//		Categories.Add(categoryIncome);
		//	}
		//}
	}
}
