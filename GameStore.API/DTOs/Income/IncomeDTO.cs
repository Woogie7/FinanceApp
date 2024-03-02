using GameStore.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace GameStore.API.DTOs.Income
{
	public record class IncomeDTO(
		decimal Amount,
		DateOnly Date,
		string CategoryIncome,
		string Currency
		);
}
