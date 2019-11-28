using System.Threading.Tasks;
using Backend.Data;
using Backend.Entities;
using Backend.Interfaces.Repositories;

namespace Backend.Repository
{
    public class AttemptDeviceRepository : BaseRepository<AttemptDevice>, IAttemptDeviceRepository
    {
        public AttemptDeviceRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }

        public Task<AttemptDevice> GetLastAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}