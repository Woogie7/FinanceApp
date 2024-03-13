namespace Finance.Domain.DTOs.Income
{
	public record class IncomeDTO(
		decimal Amount,
		DateOnly Date,
		string CategoryIncome,
		int CategoryIncomeId,
		string Currency,
		int CurrencyId
		);
}
