using Backend.Data;
using Backend.Entities;
using Backend.Interfaces.Repositories;

namespace Backend.Repository
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ApplicationDbContext dataContext) : base(dataContext)
        {
        }
    }
}