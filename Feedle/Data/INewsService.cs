﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public interface INewsService
    {
        Task<IList<News>> GetNewsAsync();
        Task AddNewsAsync(News news);
    }
}