using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Extensions;

namespace Backend.Repository
{
    /// <summary>
    /// Generieke klasse die dient als base repository voor iedere entiteit.
    /// Maak hier gebruik van, en zo nodig, kan je hem extenden.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private protected ApplicationDbContext _dataContext;

        protected BaseRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dataContext.Set<T>().Include(_dataContext.GetIncludePaths(typeof(T)))
                .FirstOrDefaultAsync(expression);
        }

        public virtual async Task<IReadOnlyList<T>> GetListAsync()
        {
            var result = await _dataContext.Set<T>().Include(_dataContext.GetIncludePaths(typeof(T))).ToListAsync();
            return result.Any() ? result : new List<T>();
        }

        public virtual async Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> expression)
        {
            var result = await _dataContext.Set<T>().Include(_dataContext.GetIncludePaths(typeof(T))).Where(expression)
                .ToListAsync();
            return result.Any() ? result : new List<T>();
        }

        public virtual async Task<T> GetLastAsync()
        {
            var result = await GetListAsync();
            return result.Any() ? result.Last() : null;
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