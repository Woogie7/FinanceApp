using Finance.Application.Features.ExpenseFeatures.Queries;
using Finance.Application.Features.IncomeFeatures.Queries;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.ExpenseFeatures.Handler
{
    public class GetAllExpenseHandler : IRequestHandler<GetAllExpenseQuery, IEnumerable<Expense>>
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly ILogger<GetAllExpenseHandler> _logger;

        public GetAllExpenseHandler(IExpenseRepository expenseRepository, ILogger<GetAllExpenseHandler> logger)
        {
            _expenseRepository = expenseRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Expense>> Handle(GetAllExpenseQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Start get all expense");

                var expenses = await _expenseRepository.GetAllAsync();

                _logger.LogInformation("Succeseful");

                return expenses;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Not Found {ex.Message}");
                return null;
            }
        }
    }
}
