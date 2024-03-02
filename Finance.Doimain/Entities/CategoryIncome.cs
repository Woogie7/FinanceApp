using GameStore.Domain.Entities.Base;

namespace GameStore.Domain.Entities;

public class CategoryIncome : Entity
{
	public required string CategoryIncomeName { get; set; }
}
