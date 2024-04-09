﻿using Finance.Domain.Entities;
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
        Task<List<Income>> GetAllAsync();
        Task<Income> AddAsync(Income entity);
        Task UpdateAsync(Income entity);
        Task DeleteAsync(Income entity);
    }
}