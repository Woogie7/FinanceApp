using Finance.Domain.Entities.Base.Finance.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities
{
    public class Expense : Entity
    {
        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }

        public int CategoryExpenseId { get; set; }
        public CategoryExpense? Category { get; set; }//Категория

        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; } //Валюта
    }
}
