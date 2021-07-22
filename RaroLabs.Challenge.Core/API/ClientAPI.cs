using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace RaroLabs.Challenge.Core.API
{
    public class ClientAPI : IClientAPI
    {
        public async Task<T> Get<T>(string url)
        {
            var uri = new Uri(url);
            var client = new HttpClient();

            var response = await client.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}