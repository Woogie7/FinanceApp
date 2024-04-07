using Finance.Domain.Entities.Base;

namespace Finance.Domain.Entities
{
	public class Income : Entity
	{
		public decimal Amount { get; set; } //Количество

		public DateOnly Date { get; set; }// Дата

		public int CategoryIncomeId { get; set; }
		public CategoryIncome? Category { get; set; }//Категория

		public int CurrencyId { get; set; }
		public Currency? Currency { get; set; } //Валюта
	}
}
