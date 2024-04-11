using Finance.Domain.Entities.Base;
using System.Text.Json.Serialization;

namespace Finance.Domain.Entities;

public class CategoryIncome : Entity
{
	public required string CategoryIncomeName { get; set; }
    [JsonIgnore]
    public ICollection<Income> Incomes { get; set; }
}
