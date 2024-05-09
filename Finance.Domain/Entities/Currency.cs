using Finance.Domain.Entities.Base.Finance.Domain.Entities.Base;

namespace Finance.Domain.Entities
{
    public class Currency : Entity
    {
        public required string CurrencyName { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}
