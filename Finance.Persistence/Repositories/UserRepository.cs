using AutoMapper;
using Finance.Application.Interface.Repositories;
using Finance.Domain.Entities.Users;
using Finance.Domain.Enum;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Finance.Application.DTOs.UserDto;

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
    public async Task Add(CreateUserDto user)
    {
        var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == (int)RoleEnum.Admin);

        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Email = user.Email,
            PasswordHash = user.PasswordHash,
            Role = role,
            UserName = user.UserName,
            RoleId = role.Id,
            Balance = 0
        };

        await _dbContext.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmail(string email)
    {

        var users = await _dbContext.Users.ToListAsync();

        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(user => user.Email == email);

        return user;
    }

    public async Task<HashSet<string>> GetUserPermissionsAsync(Guid userId)
    {
        var roles = await _dbContext.Users
            .AsNoTracking()
            .Include(r => r.Role)
            .ThenInclude(r => r.Permissions)
            .Where(u => u.Id == userId)
            .Select(u => u.Role)
            .ToListAsync();

        return roles
            .Select(r => r)
            .SelectMany(r => r.Permissions)
            .Select(r => r.Name)
            .ToHashSet();
    }
}
