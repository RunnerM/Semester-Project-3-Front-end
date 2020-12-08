using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public class CloudNewsService : INewsService
    {
        private string uri = "https://localhost:5003";
        private HttpClient client;

        public CloudNewsService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Post>> GetNewsAsync()
        {
            string message = await client.GetStringAsync(uri + "/news");
            List<Post> result = JsonSerializer.Deserialize<List<Post>>(message);
            return result;
        }

        public async Task AddNewsAsync(Post news)
        {
            string newsToSerialize = JsonSerializer.Serialize(news);
            StringContent content = new StringContent(newsToSerialize, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/news", content);
        }


        public Task AddPostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Post>> GetAllNews()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }
    }
}