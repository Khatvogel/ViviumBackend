using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    /// <summary>
    /// Interface voor de generieke repo. Voorkomt veel redundancy.
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<T> GetAsync(string id);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetListAsync();
        Task<IReadOnlyList<T>> GetListAsync(Expression<Func<T, bool>> expression);
        Task<T> GetLastAsync();
        void Detach(T entity);
    }
}