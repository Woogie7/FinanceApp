using Finance.Domain.Entities.Base.Finance.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Finance.Domain.Entities
{
    public class CategoryIncome : Entity
    {
        public required string CategoryIncomeName { get; set; }
        [JsonIgnore]
        public ICollection<Income> Incomes { get; set; }
    }
}
