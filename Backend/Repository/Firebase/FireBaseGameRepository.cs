using Backend.Entities;
using Backend.Interfaces.Firebase;

namespace Backend.Repository.Firebase
{
    public class FireBaseGameRepository : FirebaseRepository<Game>, IFireBaseGameRepository
    {
    }
}