using Finance.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.Queries
{
	public record GetAllIncomeQuery : IRequest<List<Income>>;
}
