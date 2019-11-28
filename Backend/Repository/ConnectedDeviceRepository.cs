using Backend.Data;
using Backend.Entities;
using Backend.Interfaces;

namespace Backend.Repository
{
    public class ConnectedDeviceRepository : BaseRepository<Device>, IConnectedDeviceRepository
    {
        public ConnectedDeviceRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}