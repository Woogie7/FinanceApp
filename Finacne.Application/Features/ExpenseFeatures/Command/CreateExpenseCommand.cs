using Finance.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.ExpenseFeatures.Command;

public record CreateExpenseCommand(Expense newExpense) : IRequest<Expense>;
