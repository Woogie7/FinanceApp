using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.DTOs.DtoExpense
{
    public class ExpenseDto
    {
        public int ID { get; set; }

        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }

        public string CategoryExpense { get; set; }

        public string Currency { get; set; }
    }
}
