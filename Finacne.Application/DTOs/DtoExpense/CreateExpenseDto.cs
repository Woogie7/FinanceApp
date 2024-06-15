using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.DTOs.DtoExpense
{
    public class CreateExpenseDto
    {
        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }

        public int CategoryExpenseId { get; set; }

        public int CurrencyId { get; set; }
    }
}
