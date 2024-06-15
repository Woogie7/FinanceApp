using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.DTOs.Income
{
    public class DeteilsIncomeDTO
    {
        public int id { get; set; }
        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }

        public int CategoryIncome { get; set; }

        public int Currency { get; set; }
    }
}
