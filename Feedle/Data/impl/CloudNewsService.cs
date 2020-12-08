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

        private string postFile = "posts.json";
        private IList<Post> posts;
        public Task AddPostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Post>> GetAllNews()
        {
            throw new NotImplementedException();
        }
    

//         public CloudNewsService()
//         {
//             if (!File.Exists(postFile))
//             {
//                 Seed();
//                 WritePostsToFile();
//             }
//             else
//             {
//                 string content = File.ReadAllText(postFile);
//                 posts = JsonSerializer.Deserialize<List<Post>>(content);
//             }
//         }
//
//         private void Seed()
//         {
//             Post[] posts =
//             {
//                 new Post
//                 {
//                     Title = "hvljgjblad",
//                     Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
//                     AuthorUserName = "bob the spammer."
//                 },
//                 new Post
//                 {
//                     Title = "dafadajkbjadf",
//                     Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
//                     AuthorUserName = "bob the spammer."
//                 },
//                 new Post
//                 {
//                     Title = "c",
//                     Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
//                     AuthorUserName = "bob the spammer."
//                 },
//                 new Post
//                 {
//                     Title = "e",
//                     Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
//                     AuthorUserName = "bob the spammer."
//                 }
//             };
//             this.posts = posts;
//         }
//
//         private void WritePostsToFile()
//         {
//             string productAsJson = JsonSerializer.Serialize(posts);
//             File.WriteAllText(postFile, productAsJson);
//         }
//
//
//         public async Task AddPostAsync(Post post)
//         {
//             this.posts.Add(post);
//             WritePostsToFile();
//         }
//
//         public async Task<IList<Post>> GetAllNews()
//         {
//             return posts;
//         }
    }
}