using Finance.Domain.Entities.Base;
using System.Xml.Linq;

namespace Finance.Domain.Entities;

public class Currency : Entity
{
	public required string CurrencyName { get; set; }
    public List<Income> Incomes { get; set; } = new List<Income>();
}
