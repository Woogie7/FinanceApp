﻿using Finance.Domain.Entities.Base;

namespace Finacne.Application.Repositories
{
	public interface IGenericRepository<T> where T : class, IEntity
	{
		Task<T> GetByIdAsync(int id);
		Task<List<T>> GetAllAsync();
		Task<T> AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
