using Finance.API.Data;
using Finance.Application.DTOs;
using Finance.Domain.Entities;
using Finance.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CurrencyController : ControllerBase
	{
		private readonly FinanceDBContext _financeDBContext;

		public CurrencyController(FinanceDBContext financeDBContext)
		{
			_financeDBContext = financeDBContext;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var currency = await _financeDBContext.Currencies
				.AsNoTracking()
				.ToListAsync();

			return Ok(currency);
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Currency currency)
        {
            if(currency == null)
			{
				_financeDBContext.AddAsync(currency);
				_financeDBContext.SaveChanges();
				return Ok();
			}

            return BadRequest();
        }
    }
}
