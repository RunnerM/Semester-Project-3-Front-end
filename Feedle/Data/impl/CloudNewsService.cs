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
        // private string uri = "https://localhost:5003";
        // private HttpClient client;
        //
        // public CloudNewsService()
        // {
        //     client = new HttpClient();
        // }
        //
        // public async Task<IList<News>> GetNewsAsync()
        // {
        //     string message = await client.GetStringAsync(uri + "/news");
        //     List<News> result = JsonSerializer.Deserialize<List<News>>(message);
        //     return result;
        // }
        //
        // public async Task AddNewsAsync(News news)
        // {
        //     string newsToSerialize = JsonSerializer.Serialize(news);
        //     StringContent content = new StringContent(newsToSerialize, Encoding.UTF8, "application/json");
        //     HttpResponseMessage response = await client.PostAsync(uri + "/news", content);
        // }

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