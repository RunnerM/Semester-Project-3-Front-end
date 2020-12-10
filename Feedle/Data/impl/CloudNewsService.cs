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
        public List<Post> CurrentPosts { get; set; }

        public HttpClient Client { get; set; }

        public CloudNewsService()
        {
            Client = new HttpClient();
        }
        public async Task<bool> AddPostAsync(Post post)
        {
            string postToSerialize = JsonSerializer.Serialize(post);
            Console.WriteLine(postToSerialize);
            StringContent stringContent = new StringContent(
                postToSerialize,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage responseMessage =
                await Client.PostAsync("http://localhost:5002/feedle/posts", stringContent);
            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<IList<Post>> GetAllNews()
        {
            String message = await Client.GetStringAsync("http://localhost:5002/feedle/posts");
            if (message.Length == 0)
            {
                return new List<Post>();
            }
            return JsonSerializer.Deserialize<List<Post>>(message);
        }

        public Task UpdatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Post>> GetPostsForRegisteredUser(int id)
        {
            String message = await Client.GetStringAsync("http://localhost:5002/feedle/posts/authorized?id="+id);
            if (message.Length == 0)
            {
                return new List<Post>();
            }
            return JsonSerializer.Deserialize<List<Post>>(message);
        }
    }
}