using Finance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.DTOs
{
    public class CreateIncomeDto
    {
        [Range(1,20000000)]
        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }

        public int CategoryIncomeId { get; set; }

        public int CurrencyId { get; set; }
    }
}
