using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Entities;
using Backend.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class AttemptRepository : BaseRepository<Attempt>, IAttemptRepository
    {
        public AttemptRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }

        public override async Task<IReadOnlyList<Attempt>> GetListAsync()
        {
            return await _dataContext.Attempts
                .Include(a => a.Devices)
                .ToListAsync();
        }
    }
}