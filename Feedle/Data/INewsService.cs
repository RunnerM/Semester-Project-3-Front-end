using System.Collections.Generic;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public interface INewsService
    {
        Task AddPostAsync(Post post);
        Task<IList<Post>> GetAllNews();
        Task UpdatePostAsync(Post post);
    }
}