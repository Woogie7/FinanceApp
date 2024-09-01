using AutoMapper;
using Finance.API.Controllers;
using Finance.API.Data;
using Finance.Application.DTOs;
using Finance.Application.DTOs.DtoCurrency;
using Finance.Application.DTOs.DtoExpense;
using Finance.Application.DTOs.Income;
using Finance.Application.Features.CurrencyFeatures.Command;
using Finance.Application.Features.CurrencyFeatures.Queries;
using Finance.Application.Features.IncomeFeatures.Queries;
using Finance.Domain.Entities;
using Finance.Domain.Enum;
using Finance.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CurrencyController : ControllerBase
	{
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(IMapper mapper, ILogger<CurrencyController> logger, IMediator mediator)
        {
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;
        }


        [HttpGet]
		public async Task<IActionResult> Get()
		{
            var reqestCurrency = await _mediator.Send(new GetAllCurrencyQuery());

            if (reqestCurrency == null)
            {
                return NotFound();
            }

            var currency = reqestCurrency.Select(curency => _mapper.Map<CurrencyDto>(curency));

            return Ok(currency);
		}

        [HasPermisiion(PermissionsEnum.Read)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCurrencyDto newCurrency)
        {
            var currency = _mapper.Map<Currency>(newCurrency);

            var requestCurrency = await _mediator.Send(new CreateCurrencyCommand(currency));

            var currencyDTO = _mapper.Map<CurrencyDto>(requestCurrency);

            return Ok(currencyDTO);
        }
    }
}
