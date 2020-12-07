using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Feedle.Data;
using Feedle.Models;

namespace Feedle.Data
{
    public class CloudNewsService : INewsService
    {
        //cloud
//         private Uri uri = new Uri("https://localhost:5003");
//         private HttpClient client;
//
//         public CloudNewsService()
//         {
//             client = new HttpClient();
//         }
//
//         public async Task<IList<Post>> GetNewsAsync()
//         {
//             string message = await client.GetStringAsync(uri + "/news");
//             List<Post> result = JsonSerializer.Deserialize<List<Post>>(message);
//             return result;
//         }
//
//         public async Task AddNewsAsync(Post post)
//         {
//             string newsToSerialize = JsonSerializer.Serialize(post);
//             StringContent content = new StringContent(newsToSerialize, Encoding.UTF8, "application/json");
//             HttpResponseMessage response = await client.PostAsync(uri + "/news", content);
//         }
//
//         public async Task AddPostAsync(Post post)
//         {
//             string sereliazedData = JsonSerializer.Serialize(post);
//             StringContent content = new StringContent(
//                 sereliazedData,
//                 Encoding.UTF8,
//                 "application/Json"
//             );
//             HttpResponseMessage response = await client.PostAsync(uri + "", content);
//
//         }
//
//         public async Task<IList<Post>> GetAllNews()
//         {
//             string response = await client.GetStringAsync(uri + "");
//             try
//             {
//                 IList<Post> posts = JsonSerializer.Deserialize<IList<Post>>(response);
//                 return posts;
//             }
//             catch (Exception e)
//             {
//                 throw e;
//             }
//         }
//     }
// }
//------Local----------------

        private string postFile = "posts.json";
        private IList<Post> posts;

        public CloudNewsService()
        {
            if (!File.Exists(postFile))
            {
                Seed();
                WritePostsToFile();
            }
            else
            {
                string content = File.ReadAllText(postFile);
                posts = JsonSerializer.Deserialize<List<Post>>(content);
            }
        }

        private void Seed()
        {
            Post[] posts =
            {
                new Post
                {
                    Title = "hvljgjblad",
                    Content = "dadjkblkdablqkdjba",
                    AuthorUserName = "bob the spammer."
                },
                new Post
                {
                    Title = "dafadajkbjadf",
                    Content = "dadasdadaddab",
                    AuthorUserName = "bob the spammer."
                },
                new Post
                {
                    Title = "c",
                    Content = "cc",
                    AuthorUserName = "bob the spammer."
                },
                new Post
                {
                    Title = "d",
                    Content = "dd",
                    AuthorUserName = "bob the spammer."
                },
                new Post
                {
                    Title = "e",
                    Content = "ee",
                    AuthorUserName = "bob the spammer."
                },
                new Post
                {
                    Title = "hvljgjblad",
                    Content = "dadjkblkdablqkdjba",
                    AuthorUserName = "bob the spammer."
                },
                new Post
                {
                    Title = "dafadajkbjadf",
                    Content = "dadasdadaddab",
                    AuthorUserName = "bob the spammer."
                },
                new Post
                {
                    Title = "c",
                    Content = "cc",
                    AuthorUserName = "bob the spammer."
                },
                new Post
                {
                    Title = "d",
                    Content = "dd",
                    AuthorUserName = "bob the spammer."
                },
                new Post
                {
                    Title = "e",
                    Content = "ee",
                    AuthorUserName = "bob the spammer."
                }
            };
            this.posts = posts;
        }

        private void WritePostsToFile()
        {
            string productAsJson = JsonSerializer.Serialize(posts);
            File.WriteAllText(postFile, productAsJson);
        }


        public async Task AddPostAsync(Post post)
        {
            this.posts.Add(post);
            WritePostsToFile();
        }

        public async Task<IList<Post>> GetAllNews()
        {
            return posts;
        }
    }
}