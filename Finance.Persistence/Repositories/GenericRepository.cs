using Finacne.Application.Repositories;
using Finance.Domain.Entities.Base;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Finance.Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
	{
		private readonly FinanceDBContext _dbContext;
		public GenericRepository(FinanceDBContext dbContext) 
		{
			_dbContext = dbContext;
		}
		public async Task<T> AddAsync(T entity)
		{
			await _dbContext.Set<T>().AddAsync(entity);
			return entity;
		}

		public Task UpdateAsync(T entity)
		{
			T exist = _dbContext.Set<T>().Find(entity.Id);
			_dbContext.Entry(exist).CurrentValues.SetValues(entity);
			return Task.CompletedTask;
		}

		public Task DeleteAsync(T entity)
		{
			_dbContext.Set<T>().Remove(entity);
			return Task.CompletedTask;
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _dbContext
				.Set<T>()
				.ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbContext.Set<T>().FindAsync(id);
		}
	}
}
