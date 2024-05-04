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
    public class DeleteIncomeHandler : IRequestHandler<DeleteIncomeCommand, Income>
    {
        private readonly IIncomeRepository _repository;
        private readonly ILogger<GetIncomeByIdHandler> _logger;

        public DeleteIncomeHandler(IIncomeRepository repository, ILogger<GetIncomeByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        public Task<Income> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            var income = _repository.DeleteAsync(request.id);
            return income;
        }
    }
}
