﻿using System;
using System.Collections.Generic;
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

        public async Task<IList<News>> GetNewsAsync()
        {
            string message = await client.GetStringAsync(uri + "/news");
            List<News> result = JsonSerializer.Deserialize<List<News>>(message);
            return result;
        }

        public async Task AddNewsAsync(News news)
        {
            string newsToSerialize = JsonSerializer.Serialize(news);
            StringContent content = new StringContent(newsToSerialize, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri + "/news", content);
        }
    }
}