﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<T> GetByIdAsync(int id);
		Task<IReadOnlyList<T>> ListAllAsync();
		Task AddAsync(T entity);
		void Update(T entity);
		Task DeleteAsync(T entity);
		Task SaveAsync();
	}
}
