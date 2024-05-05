using Finance.Domain.Entities.Base.Finance.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Domain.Entities
{
    public class Currency : Entity
    {
        public required string CurrencyName { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}
