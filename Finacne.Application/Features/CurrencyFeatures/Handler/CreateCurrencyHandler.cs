using Finance.Application.Features.CurrencyFeatures.Command;
using Finance.Application.Features.IncomeFeatures.Command;
using Finance.Application.Features.IncomeFeatures.Handler;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.CurrencyFeatures.Handler
{
    internal class CreateCurrencyHandler : IRequestHandler<CreateCurrencyCommand, Currency>
    {
        private readonly ICurrencyRepository _repository;
        private readonly ILogger<GetIncomeByIdHandler> _logger;

        public CreateCurrencyHandler(ICurrencyRepository repository, ILogger<GetIncomeByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public Task<Currency> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currencies = _repository.AddAsync(request.newCurrency);
            return currencies;
        }
    }
}
