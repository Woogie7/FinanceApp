using Finance.Domain.Entities.Base;

namespace Finance.Domain.Entities;

public class CategoryIncome : Entity
{
	public required string CategoryIncomeName { get; set; }
    public ICollection<Income> Incomes { get; set; }
}
