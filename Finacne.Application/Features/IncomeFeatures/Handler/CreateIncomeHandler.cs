using Finance.Application.Features.IncomeFeatures.Command;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.IncomeFeatures.Handler
{
    public class CreateIncomeHandler : IRequestHandler<CreateIncomeCommand, Income>
    {
        private readonly IIncomeRepository _repository;
        private readonly ILogger<GetIncomeByIdHandler> _logger;

        public CreateIncomeHandler(IIncomeRepository repository, ILogger<GetIncomeByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        public Task<Income> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = _repository.AddAsync(request.newIncome);
            return income;
        }
    }
}
