namespace Finance.Domain.DTOs.Income
{
	public record class IncomeDetailsDTO
	(
		decimal Amount,
		DateOnly Date,
		int CategoryIncome,
		int Currency);
}
