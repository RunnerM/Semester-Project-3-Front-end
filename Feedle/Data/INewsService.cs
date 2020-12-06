﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public interface INewsService
    {
        Task<IList<Post>> GetNewsAsync();
        Task AddNewsAsync(Post post);
        Task<bool> DeletePostAsync(Post post);

    }
}