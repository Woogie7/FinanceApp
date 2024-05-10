using AutoMapper;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities.Users;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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
    public async Task Add(User user)
    {
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == email);

        return user;
    }
}
