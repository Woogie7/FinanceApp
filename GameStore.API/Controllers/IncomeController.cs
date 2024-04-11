using Microsoft.AspNetCore.Mvc;
using MediatR;
using Finance.Application.Features.IncomeFeatures.Queries;
using Finance.Domain.Entities;
using Finance.Application.Features.IncomeFeatures.Command;
using Finance.Application.DTOs;
using AutoMapper;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class IncomeController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly ILogger<IncomeController> _logger;

        public IncomeController(IMediator mediator, IMapper mapper, ILogger<IncomeController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
		public async Task<IActionResult> Get()
		{
			var reqestIncome = await _mediator.Send(new GetAllIncomeQuery());

            var income = reqestIncome.Select(income => _mapper.Map<IncomeDTO>(income));

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

            var incomeDTO = _mapper.Map<IncomeDTO>(income);

            return Ok(incomeDTO);
        }

		[HttpPost]
		public async Task<IActionResult> Post([FromBody]CreateIncomeDto newIncome)
		{

			var income = _mapper.Map<Income>(newIncome);

            var requestIncome = await _mediator.Send(new CreateIncomeCommand(income));

            var incomeDTO = _mapper.Map<IncomeDTO>(requestIncome);

            return Ok(incomeDTO);
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
