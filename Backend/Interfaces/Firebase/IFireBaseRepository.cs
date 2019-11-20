using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Interfaces.Firebase
{
    public interface IFireBaseRepository<T> where T : class
    {
        /// <summary>
        /// Roep deze methode als eerste aan om het pad Firebase te bepalen.
        /// </summary>
        /// <param name="path"></param>
        void Initialize(string path);
        Task<T> SetAsync(T data);
        Task<T> PushAsync(T data);
        Task<List<T>> GetAsync();
        Task<T> UpdateAsync(T data);
    }
}