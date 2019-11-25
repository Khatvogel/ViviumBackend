﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    /// <summary>
    /// Generieke klasse die dient als base repository voor iedere entiteit.
    /// Maak hier gebruik van, en zo nodig, kan je hem extenden.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dataContext;

        protected BaseRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }
        
        public virtual async Task<T> GetAsync(string id)
        {
            return await _dataContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync()
        {
            var result = await _dataContext.Set<T>().ToListAsync();
            return result.Any() ? result : new List<T>();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public void Detach(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Detached;
        }
    }
}