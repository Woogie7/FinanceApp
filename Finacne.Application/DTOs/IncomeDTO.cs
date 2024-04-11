using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.DTOs
{
    public class IncomeDTO
    {
        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }

        public string CategoryIncome { get; set; }

        public string Currency { get; set; }
    }
}
