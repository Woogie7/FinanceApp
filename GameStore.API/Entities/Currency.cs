using GameStore.API.Entities.Base;

namespace GameStore.API.Entities
{
	public class Currency : Entity
	{
		public required string CurrencyName { get; set; }
	}
}
