using Finance.Application.Features.IncomeFeatures.Queries;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Finance.Application.Features.IncomeFeatures.Handler
{
    public class GetIncomeByIdHandler : IRequestHandler<GetIncomeByIdQuery, Income>
    {
        private readonly IGenericRepository<Income> _repository;
        private readonly ILogger<GetIncomeByIdHandler> _logger;
        public GetIncomeByIdHandler(IGenericRepository<Income> repository, ILogger<GetIncomeByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Income> Handle(GetIncomeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start find income by id");

                var income = await _repository.GetByIdAsync(request.id);

                _logger.LogInformation("Succeseful find");

                return income;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Not Found {ex.Message}");
                return null;
            }
        }
    }
}
