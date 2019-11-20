using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    /// <summary>
    /// Interface voor de generieke repo. Voorkomt veel redundancy.
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}