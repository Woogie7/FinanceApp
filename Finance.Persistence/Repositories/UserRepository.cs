using AutoMapper;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities;
using Finance.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FinanceDBContext _dbContext;
    private readonly IMapper _mapper;
    public UserRepository(FinanceDBContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public Task Add(User user)
    {
        _dbContext.uS
    }

    public Task<User> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}
