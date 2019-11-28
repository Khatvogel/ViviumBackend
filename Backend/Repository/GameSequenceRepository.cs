using Backend.Data;
using Backend.Entities;
using Backend.Interfaces.Repositories;

namespace Backend.Repository
{
    public class GameSequenceRepository : BaseRepository<GameSequence>, IGameSequenceRepository
    {
        public GameSequenceRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}