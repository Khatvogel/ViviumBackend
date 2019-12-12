using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Backend.Interfaces.Firebase;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Newtonsoft.Json;

namespace Backend.Repository.Firebase
{
    public class FirebaseRepository<T> : IFireBaseRepository<T> where T : class
    {
        private string _path;
        private IFirebaseClient _client;
        private readonly HttpClient _httpClient;
        private string _baseUrl = "https://vivium.firebaseio.com/";

        protected FirebaseRepository(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
        }

        public void Initialize(string path)
        {
            _path = path;
            var config = new FirebaseConfig
            {
                AuthSecret = "",
                BasePath = "https://vivium.firebaseio.com/"
            };

            _client = new FirebaseClient(config);
            _baseUrl = $"{_baseUrl}/{path}.json";
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

        public virtual async Task<List<T>> GetListAsync()
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            var content = await response.Content.ReadAsStringAsync();
            return content.Equals("null")
                ? new List<T>()
                : JsonConvert.DeserializeObject<Dictionary<string, T>>(content).Values.ToList();
        }

        public virtual async Task<T> UpdateAsync(T data)
        {
            var response = await _client.UpdateAsync(_path, data);
            return response.ResultAs<T>();
        }
    }
}