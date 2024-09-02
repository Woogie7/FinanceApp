using Finance.Application.Features.IncomeFeatures.Command;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using Finance.Domain.Entities.Users;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Features.IncomeFeatures.Handler
{
    public class CreateIncomeHandler : IRequestHandler<CreateIncomeCommand, Income>
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetIncomeByIdHandler> _logger;

        public CreateIncomeHandler(IIncomeRepository incomeRepository, 
                                    ILogger<GetIncomeByIdHandler> logger, 
                                    IUserRepository userRepository, 
                                    IUnitOfWork unitOfWork)
        {
            _incomeRepository = incomeRepository;
            _userRepository = userRepository;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        public async Task<Income> Handle(CreateIncomeCommand request, CancellationToken cancellationToken)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                await _userRepository.AddBalanceAsync(request.newIncome.UserId, request.newIncome.Amount);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                var income = await _incomeRepository.AddAsync(request.newIncome);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                transaction.Commit();
                return income;
            }
            catch (Exception) 
            {
                transaction.Rollback();
                throw;
            }
            
        }
    }
}
