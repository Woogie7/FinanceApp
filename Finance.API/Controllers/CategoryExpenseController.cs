using AutoMapper;
using Finance.Application.DTOs.DtoCategory;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryExpenseController : ControllerBase
    {
        private readonly IMapper _mapper;

        public CategoryExpenseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var category = await _financeDBContext.CategoryExpenses.AsNoTracking().ToListAsync();

            //var categoryExpenseDto = category.Select(categor => _mapper.Map<CategoryExpenseDto>(categor));

            return Ok();
        }
    }
}
