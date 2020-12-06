﻿using System;
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
        
        
        //placeholders:
        private List<Post> posts= new List<Post>();
        private string postFile = "posts.json";

        public CloudNewsService()
        {
            if (!File.Exists(postFile))
            {
                File.Create(postFile);
            }
            else
            {
                readPosts();
            }
        }

        private void readPosts()
        {
            string file = File.ReadAllText(postFile);
            posts = JsonSerializer.Deserialize<List<Post>>(file);
        }

        public async Task<IList<Post>> GetNewsAsync()
        {
            return posts;
        }
        

        public async Task AddNewsAsync(Post post)
        {
            posts.Add(post);
            string fileContent = JsonSerializer.Serialize(posts);
            File.WriteAllText(postFile, fileContent);
        }

        public async Task<bool> DeletePostAsync(Post post)
        {
            bool result=posts.Remove(post);
            return result;
        }
    }
}