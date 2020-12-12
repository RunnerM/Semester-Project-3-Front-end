using System.Collections.Generic;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public interface INewsService
    {
        Task<bool> AddPostAsync(Post post);
        Task<IList<Post>> GetAllNews();
        Task UpdatePostAsync(Post post);

        Task<List<Post>> GetPostsForRegisteredUser(int id);

        Task<bool> CommentPost(Comment comment, int postId);
        Task<bool> DeletePost(Post post);
    }
}