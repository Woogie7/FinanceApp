using Finance.Domain.Entities.Base.Finance.Domain.Entities.Base;
using Finance.Domain.Entities.Users;
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
        public Currency? Currency { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
