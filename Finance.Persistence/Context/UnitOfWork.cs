using Finance.Application.Interface.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FinanceDBContext _dbContext;

        public UnitOfWork(FinanceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IDbTransaction BeginTransaction()
        {
            var transaction = _dbContext.Database.BeginTransaction();

            return transaction.GetDbTransaction();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
