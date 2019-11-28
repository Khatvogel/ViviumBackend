using System.Net.Http;
using Backend.Entities;
using Backend.Interfaces.Firebase;

namespace Backend.Repository.Firebase
{
    public class FireBaseDeviceRepository : FirebaseRepository<Device>, IFireBaseDeviceRepository
    {
        public FireBaseDeviceRepository(IHttpClientFactory httpClient) : base(httpClient)
        {
        }
    }
}