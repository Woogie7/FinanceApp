using Microsoft.AspNetCore.Mvc;
using MediatR;
using Finance.Application.Features.IncomeFeatures.Queries;
using Finance.Application.Features.IncomeFeatures.Command;
using Finance.Application.DTOs;
using AutoMapper;
using Finance.Domain.Model;
using Finance.Domain.Entities;
using Finance.Application.DTOs.Income;
using Finance.Domain.Enum;
using Finance.Infrastructure.Authentication;

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

        [HasPermisiion(PermissionsEnum.Read)]
        [HttpGet]
		public async Task<IActionResult> Get()
		{
            var userId = User.FindFirst("userId")?.Value;

            var reqestIncome = await _mediator.Send(new GetAllIncomeQuery(new Guid(userId)));

			if(reqestIncome == null)
			{
				return NotFound();
			}

            var income = reqestIncome.Select(income => _mapper.Map<IncomeDTO>(income));

            return Ok(income);
		}

		[HttpGet("Cat/{selectedCurrency}")]
        public async Task<IActionResult> GetCategorySum(string selectedCurrency)
		{
			//if(selectedCurrency == null || selectedCurrency.Length == 0)
			//{
			//	return Ok(null);
			//}
			////var categoryAmounts = await _mediator.Send(new GetAllIncomeQuery());
			////var income = categoryAmounts.Select(income => _mapper.Map<IncomeDTO>(income));
			//var i = income.Where(i => i.Currency == selectedCurrency)
			//	.GroupBy(i => i.CategoryIncome)
			//	.Select(g => new CategorySummary
			//	{
			//		CategoryName = g.Key,
			//		TotalAmount = g.Sum(a => a.Amount)
			//	});

			return Ok();
		}


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

        [HasPermisiion(PermissionsEnum.Create)]
        [HttpPost]
		public async Task<IActionResult> Post([FromBody]CreateIncomeDto newIncome)
		{
			var income = _mapper.Map<Income>(newIncome);

            var userId = User.FindFirst("userId")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User not authenticated.");
            }
            income.UserId = new Guid(userId);

            var requestIncome = await _mediator.Send(new CreateIncomeCommand(income));

            var incomeDTO = _mapper.Map<IncomeDTO>(requestIncome);

            return Ok(incomeDTO);
		}

		//[HttpPut("{id}")]
		//public async Task<IActionResult> Put(UpdateIncomeDTO updateIncome, int id)
		//{
		//	var income = await _financeDBContext.Incomes.FindAsync(id);

		//	if (income != null)
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

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
            await _mediator.Send(new DeleteIncomeCommand(id));

            return NoContent();
        }

        [HttpDelete("DeleteAllIncome")]
        public async Task<IActionResult> DeleteAllIncome()
        {
            await _mediator.Send(new DeleteAllIncomeCommand());

            return NoContent();
        }
    }
}
