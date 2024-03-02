using GameStore.Domain.Entities.Base;

namespace GameStore.Domain.Entities;

public class Currency : Entity
{
	public required string CurrencyName { get; set; }
}
