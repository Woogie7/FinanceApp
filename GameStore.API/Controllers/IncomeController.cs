using Finance.Domain.Model;
using Finance.API.Data;
using Finance.API.DTOs.Income;
using Finance.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IncomeController : ControllerBase
	{
		private readonly FinanceDBContext _financeDBContext;

		public IncomeController(FinanceDBContext financeDBContext)
		{
			_financeDBContext = financeDBContext;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var incomes = await _financeDBContext.Incomes
				.Include(i => i.Category)
				.Include(i => i.Currency)
				.AsNoTracking()
				.ToListAsync();

			return Ok(incomes);
		}
		[HttpGet]
		[Route("Cat")]
		public async Task<IActionResult> GetCategorySum()
		{
			var categoryAmounts = _financeDBContext.Incomes
			.GroupBy(i => i.Category.CategoryIncomeName)
			.Select(g=> new CategorySummary {
				CategoryName = g.Key,
				TotalAmount = g.Sum(a=> a.Amount)
			});

			return Ok(categoryAmounts);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var income = await _financeDBContext.Incomes.FindAsync(id);

			if(income == null)
			{
				return NotFound();
			}

			IncomeDetailsDTO incomeDTO = new
			(
				income.Amount,
				income.Date,
				income.CategoryIncomeId,
				income.CurrencyId
			);

			return Ok(incomeDTO);
		}
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateIncomeDTO newIncome)
		{
			Income income = new()
			{
				Amount = newIncome.Amount,
				Date = newIncome.Date,
				Category = _financeDBContext.CategoryIncomes.Find(newIncome.CategoryIncomeId),
				CategoryIncomeId = newIncome.CategoryIncomeId,
				Currency = _financeDBContext.Currencies.Find(newIncome.CurrencyId),
				CurrencyId = newIncome.CurrencyId
			};

			await _financeDBContext.Incomes.AddAsync(income);
			await _financeDBContext.SaveChangesAsync();

			IncomeDTO incomeDTO = new
			(
				income.Amount,
				income.Date,
				income.Category!.CategoryIncomeName,
				income.Currency!.CurrencyName
			);

			return Ok(incomeDTO);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(UpdateIncomeDTO updateIncome, int id)
		{
			var income = await _financeDBContext.Incomes.FindAsync(id);

			if(income != null)
			{
				income.Amount = updateIncome.Amount;
				income.Date = updateIncome.Date;
				income.Category = _financeDBContext.CategoryIncomes.Find(updateIncome.CategoryIncomeId);
				income.CategoryIncomeId = updateIncome.CategoryIncomeId;
				income.Currency = _financeDBContext.Currencies.Find(updateIncome.CurrencyId);
				income.CurrencyId = updateIncome.CurrencyId;

				await _financeDBContext.SaveChangesAsync();

				IncomeDTO incomeDTO = new
				(
					income.Amount,
					income.Date,
					income.Category!.CategoryIncomeName,
					income.Currency!.CurrencyName
				);

				return Ok(incomeDTO);
			}

			return NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var income = await _financeDBContext.Incomes.Where(i => i.Id == id).ExecuteDeleteAsync();

			return NoContent();
		}
	}
}
