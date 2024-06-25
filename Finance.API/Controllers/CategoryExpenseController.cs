using AutoMapper;
using Finance.Application.DTOs.DtoCategory;
using Finance.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryExpenseController : ControllerBase
    {
        private readonly FinanceDBContext _financeDBContext;
        private readonly IMapper _mapper;

        public CategoryExpenseController(FinanceDBContext financeDBContext, IMapper mapper)
        {
            _financeDBContext = financeDBContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var category = await _financeDBContext.CategoryExpenses.AsNoTracking().ToListAsync();

            var categoryExpenseDto = category.Select(categor => _mapper.Map<CategoryExpenseDto>(categor));

            return Ok(categoryExpenseDto);
        }
    }
}
