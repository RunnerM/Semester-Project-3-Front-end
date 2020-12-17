using System.Collections.Generic;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public interface INewsService
    {
        Task<bool> AddPostAsync(Post post);
        Task<IList<Post>> GetAllNews();
        Task<bool> UpdatePostAsync(Post post);

        Task<List<Post>> GetPostsForRegisteredUser(int id);

        Task<bool> CommentPost(Comment comment, int postId);
        Task<bool> DeletePost(int postId);
        
        Task<bool> DeleteComment(int postId, int commentId);

        Task<bool> MakePostReaction(PostReaction postReaction);

        Task<bool> DeletePostReaction(int postReactionId);

        Task<bool> UpdatePostReaction(PostReaction postReaction);

        Task<Post> GetPostById(int posId);
        
    }
}