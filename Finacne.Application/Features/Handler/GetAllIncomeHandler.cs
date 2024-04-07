using Finance.Application.Features.Queries;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.Handler
{
	public class GetAllIncomeHandler : IRequestHandler<GetAllIncomeQuery, List<Income>>
	{
		private readonly IGenericRepository<Income> _incomeRepository;

		public GetAllIncomeHandler(IGenericRepository<Income> IncomeRepository)
		{
			_incomeRepository = IncomeRepository;
		}

		public async Task<List<Income>> Handle(GetAllIncomeQuery request, CancellationToken cancellationToken)
		{
			return await _incomeRepository.GetAllAsync();
		}
	}
}
