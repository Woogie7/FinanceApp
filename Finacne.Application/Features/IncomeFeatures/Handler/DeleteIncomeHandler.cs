﻿using Finance.Application.Features.IncomeFeatures.Command;
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
    public class DeleteIncomeHandler : IRequestHandler<DeleteIncomeCommand, bool>
    {
        private readonly IIncomeRepository _repository;
        private readonly ILogger<DeleteIncomeHandler> _logger;

        public DeleteIncomeHandler(IIncomeRepository repository, ILogger<DeleteIncomeHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(DeleteIncomeCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            try
            {
                await _repository.DeleteAsync(request.id);  
                _logger.LogInformation($"Income with ID {request.id} deleted successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting income with ID {request.id}.");
                throw;  
            }

            return true;
        }
    }
}
