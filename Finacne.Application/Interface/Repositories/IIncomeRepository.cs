using Finance.Domain.Entities;
using Finance.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Interface.Repositories
{
    public interface IIncomeRepository
    {
        Task<Income> GetByIdAsync(int id);
        Task<IEnumerable<Income>> GetAllAsync();
        Task<IEnumerable<Income>> GetIncomeByUserIdAsync(Guid userid);
        Task<Income> AddAsync(Income entity);
        Task UpdateAsync(Income entity);
        Task DeleteAsync(int id);
        Task DeleteAllAsync();
    }
}
