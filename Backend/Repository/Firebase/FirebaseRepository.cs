using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Interfaces.Firebase;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;

namespace Backend.Repository.Firebase
{
    public class FirebaseRepository<T> : IFireBaseRepository<T> where T : class
    {
        private string _path;
        private IFirebaseClient _client;

        public void Initialize(string path)
        {
            _path = path;
            var config = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = "https://vivium.firebaseio.com/"
            };
            
            _client = new FirebaseClient(config);
        }

        public virtual async Task<T> SetAsync(T data)
        {
            var response = await _client.SetAsync(_path, data);
            return response.ResultAs<T>();
        }

        public virtual async Task<T> PushAsync(T data)
        {
            var response = await _client.PushAsync(_path, data);
            return response.ResultAs<T>();
        }

        public virtual async Task<List<T>> GetAsync()
        {
            var response = await _client.GetAsync(_path);
            return response.ResultAs<List<T>>();
        }

        public virtual async Task<T> UpdateAsync(T data)
        {
            var response = await _client.UpdateAsync(_path, data);
            return response.ResultAs<T>();
        }
    }
}