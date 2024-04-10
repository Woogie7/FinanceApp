using Microsoft.AspNetCore.Mvc;
using MediatR;
using Finance.Application.Features.IncomeFeatures.Queries;
using Finance.Domain.Entities;
using Finance.Application.Features.IncomeFeatures.Command;
using Finance.Application.DTOs;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class IncomeController : ControllerBase
	{
		private readonly IMediator _mediator;
		public readonly ILogger _medi;

		public IncomeController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var income = await _mediator.Send(new GetAllIncomeQuery());

            return Ok(income);
		}

		//[HttpGet]
		//[Route("Cat")]
		//public async Task<IActionResult> GetCategorySum()
		//{
		//	var categoryAmounts = _financeDBContext.Incomes
		//	.GroupBy(i => i.Category.CategoryIncomeName)
		//	.Select(g => new CategorySummary
		//	{
		//		CategoryName = g.Key,
		//		TotalAmount = g.Sum(a => a.Amount)
		//	});

		//	return Ok(categoryAmounts);
		//}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var income = await _mediator.Send(new GetIncomeByIdQuery(id));

			if (income == null)
			{
				return NotFound();
			}

			//IncomeDetailsDTO incomeDTO = new
			//(
			//	income.Amount,
			//	income.Date,
			//	income.CategoryIncomeId,
			//	income.CurrencyId
			//);

			return Ok(income);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]CreateIncomeDto newIncome)
		{

			var income = new Income()
			{
				Amount = newIncome.Amount,
				CurrencyId = newIncome.CurrencyId,
				CategoryIncomeId = newIncome.CategoryIncomeId,
				Date = newIncome.Date,
			};

            income = await _mediator.Send(new CreateIncomeCommand(income));

			return Ok(income);
		}

		//[HttpPut("{id}")]
		//public async Task<IActionResult> Put(UpdateIncomeDTO updateIncome, int id)
		//{
		//	var income = await _financeDBContext.Incomes.FindAsync(id);

		//	if(income != null)
		//	{
		//		income.Amount = updateIncome.Amount;
		//		income.Date = updateIncome.Date;
		//		income.Category = _financeDBContext.CategoryIncomes.Find(updateIncome.CategoryIncomeId);
		//		income.CategoryIncomeId = updateIncome.CategoryIncomeId;
		//		income.Currency = _financeDBContext.Currencies.Find(updateIncome.CurrencyId);
		//		income.CurrencyId = updateIncome.CurrencyId;

		//		await _financeDBContext.SaveChangesAsync();

		//		return Ok(income);
		//	}

		//	return NotFound();
		//}

		//[HttpDelete("{id}")]
		//public async Task<IActionResult> Delete(int id)
		//{
		//	var income = await _financeDBContext.Incomes.Where(i => i.Id == id).ExecuteDeleteAsync();

		//	return NoContent();
		//}
	}
}
