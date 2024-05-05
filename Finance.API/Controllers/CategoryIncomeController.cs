using Finance.API.Data;
using Finance.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryIncomeController : ControllerBase
	{
		private readonly FinanceDBContext _financeDBContext;

		public CategoryIncomeController(FinanceDBContext financeDBContext)
		{
			_financeDBContext = financeDBContext;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var currency = await _financeDBContext.CategoryIncomes.ToListAsync();

			return Ok(currency);
		}
	}
}
