using Backend.Data;
using Backend.Entities;
using Backend.Interfaces;

namespace Backend.Repository
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}