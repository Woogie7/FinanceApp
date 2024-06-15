using Finance.Application.Features.ExpenseFeatures.Command;
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

namespace Finance.Application.Features.ExpenseFeatures.Handler
{
    public class CreateExpenseHandler : IRequestHandler<CreateExpenseCommand, Expense>
    {
        private readonly IExpenseRepository _repository;

        public CreateExpenseHandler(IExpenseRepository repository)
        {
            _repository = repository;
        }


        public Task<Expense> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = _repository.AddAsync(request.newExpense);
            return expense;
        }
    }
}
