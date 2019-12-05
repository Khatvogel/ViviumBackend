using Backend.Data;
using Backend.Entities;
using Backend.Interfaces.Repositories;

namespace Backend.Repository
{
    public class HintRepository : BaseRepository<Hint>, IHintRepository
    {
        public HintRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}