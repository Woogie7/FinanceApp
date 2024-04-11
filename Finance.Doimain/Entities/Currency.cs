using Finance.Domain.Entities.Base;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Finance.Domain.Entities;

public class Currency : Entity
{
	public required string CurrencyName { get; set; }
    public ICollection<Income> Incomes { get; set; }
}
