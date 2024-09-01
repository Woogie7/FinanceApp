using Finance.Domain.Entities.Base.Finance.Domain.Entities.Base;
using Finance.Domain.Entities.Users;

namespace Finance.Domain.Entities
{
    public class Income : Entity
    {
        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }

        public int CategoryIncomeId { get; set; }
        public CategoryIncome? Category { get; set; }

        public int CurrencyId { get; set; }
        public Currency? Currency { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
