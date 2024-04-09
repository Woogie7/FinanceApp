using Finance.Application.Features.IncomeFeatures.Queries;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Finance.Application.Features.IncomeFeatures.Handler
{
    public class GetIncomeByIdHandler : IRequestHandler<GetIncomeByIdQuery, Income>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly ILogger<GetIncomeByIdHandler> _logger;
        public GetIncomeByIdHandler(IIncomeRepository incomeRepository, ILogger<GetIncomeByIdHandler> logger)
        {
            _incomeRepository = incomeRepository;
            _logger = logger;
        }
        public async Task<Income> Handle(GetIncomeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start find income by id");

                var income = await _incomeRepository.GetByIdAsync(request.id);

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
