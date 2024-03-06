using Finance.Domain.Entities.Base;

namespace Finance.Domain.Entities;

public class Currency : Entity
{
	public required string CurrencyName { get; set; }
}
