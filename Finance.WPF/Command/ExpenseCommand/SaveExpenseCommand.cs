namespace Finance.Command.ExpenseCommand
{
    //internal class SaveExpenseCommand : BaseCommand
    //{
    //	private readonly ExpanseViewModel _expanseViewModel;
    //	private readonly IExpеnseService _expanseService;

    //	public SaveExpenseCommand(ExpanseViewModel expanseViewModel, IExpеnseService expеnseService)
    //	{
    //		_expanseService = expеnseService;

    //		_expanseViewModel = expanseViewModel;
    //		_expanseViewModel.PropertyChanged += OnPropertyChanged;
    //	}

    //	public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    //	{
    //		OnCanExecuteChanged();
    //	}

    //	public override bool CanExecute(object parameter)
    //	{
    //		return !string.IsNullOrEmpty(_expanseViewModel.Amount) &&
    //			   _expanseViewModel.SelectedCurrency != null &&
    //			   _expanseViewModel.SelectedCategory != null;
    //	}


    //	public override void Execute(object parameter)
    //	{
    //		try
    //		{
    //			Expense newExpense = new Expense
    //			{
    //				Amount = decimal.Parse(_expanseViewModel.Amount),
    //				Currency = _expanseViewModel.SelectedCurrency,
    //				Date = _expanseViewModel.SelectedDate,
    //				Category = _expanseViewModel.SelectedCategory
    //			};

    //			_expanseViewModel.Expenses.Add(newExpense);
    //			_expanseService.Create(newExpense);

    //			_expanseViewModel.Amount = string.Empty;
    //			_expanseViewModel.SelectedCurrency = null;
    //			_expanseViewModel.SelectedDate = DateTime.Today;
    //			_expanseViewModel.SelectedCategory = null;

    //		}
    //		catch (FormatException ex)
    //		{
    //			MessageBox.Show("Вы ввели некорректное значение для суммы дохода.");
    //		}
    //		catch (Exception ex)
    //		{
    //			MessageBox.Show("Произошла ошибка при сохранении дохода: " + ex.Message);
    //		}
    //	}
    //}
}
