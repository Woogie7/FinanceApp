using AutoMapper;
using Finance.Application.DTOs;
using Finance.Application.DTOs.DtoExpense;
using Finance.Application.DTOs.Income;
using Finance.Application.Features.ExpenseFeatures.Command;
using Finance.Application.Features.ExpenseFeatures.Queries;
using Finance.Application.Features.IncomeFeatures.Command;
using Finance.Application.Features.IncomeFeatures.Queries;
using Finance.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Finance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<ExpenseController> _logger;

        public ExpenseController(IMediator mediator, IMapper mapper, ILogger<ExpenseController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reqestExpense = await _mediator.Send(new GetAllExpenseQuery());

            if (reqestExpense == null)
            {
                return NotFound();
            }

            var expense = reqestExpense.Select(expense => _mapper.Map<ExpenseDto>(expense));

            return Ok(expense);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateExpenseDto newExpense)
        {
            var expense = _mapper.Map<Expense>(newExpense);

            var requestIncome = await _mediator.Send(new CreateExpenseCommand(expense));

            return Ok(newExpense);
        }
    }
}
