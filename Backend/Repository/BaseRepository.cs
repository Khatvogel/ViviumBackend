using System.Collections.Generic;
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
        public readonly ApplicationDbContext DataContext;

        protected BaseRepository(ApplicationDbContext dataContext)
        {
            DataContext = dataContext;
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await DataContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await DataContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await DataContext.Set<T>().AddAsync(entity);
            await DataContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            DataContext.Entry(entity).State = EntityState.Modified;
            await DataContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            DataContext.Set<T>().Remove(entity);
            await DataContext.SaveChangesAsync();
        }
    }
}