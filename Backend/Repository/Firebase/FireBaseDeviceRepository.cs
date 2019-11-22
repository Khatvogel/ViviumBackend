using Backend.Entities;
using Backend.Interfaces.Firebase;

namespace Backend.Repository.Firebase
{
    public class FireBaseDeviceRepository : FirebaseRepository<ConnectedDevice>, IFireBaseDeviceRepository
    {
    }
}