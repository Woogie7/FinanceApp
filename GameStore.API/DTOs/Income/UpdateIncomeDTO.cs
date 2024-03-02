using System.ComponentModel.DataAnnotations;

namespace GameStore.API.DTOs.Income
{
	public record class UpdateIncomeDTO(
		[Range(1, 1000000)] decimal Amount,
		DateOnly Date,
		int CategoryIncomeId,
		int CurrencyId);
}
