using Finance.Application.Features.IncomeFeatures.Command;
using Finance.Application.Interface.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.IncomeFeatures.Handler
{
    public class DeleteAllIncomeHandler : IRequestHandler<DeleteAllIncomeCommand, bool>
    {
        private readonly IIncomeRepository _repository;
        private readonly ILogger<DeleteAllIncomeHandler> _logger;

        public DeleteAllIncomeHandler(IIncomeRepository repository, ILogger<DeleteAllIncomeHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteAllIncomeCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                await _repository.DeleteAllAsync();
                _logger.LogInformation($"All incomes deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting all incomes.");
                throw;
            }

            return true;
        }
    }
}
