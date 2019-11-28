using System.Threading.Tasks;
using Backend.Data;
using Backend.Entities;
using Backend.Interfaces.Repositories;

namespace Backend.Repository
{
    public class AttemptRepository : BaseRepository<Attempt>, IAttemptRepository
    {
        public AttemptRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}