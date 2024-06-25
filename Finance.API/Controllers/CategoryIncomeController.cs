using AutoMapper;
using Finance.API.Data;
using Finance.Application.DTOs.DtoCategory;
using Finance.Application.DTOs.DtoExpense;
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
        private readonly IMapper _mapper;

        public CategoryIncomeController(FinanceDBContext financeDBContext, IMapper mapper)
        {
            _financeDBContext = financeDBContext;
            _mapper = mapper;
        }

        [HttpGet]
		public async Task<IActionResult> Get()
		{
			var category = await _financeDBContext.CategoryIncomes.AsNoTracking().ToListAsync();

            var categoryIncoemDto = category.Select(categor => _mapper.Map<CategoryIncomeDto>(categor));

            return Ok(categoryIncoemDto);
        }
	}
}
