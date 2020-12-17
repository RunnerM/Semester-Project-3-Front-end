using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Feedle.Models;

namespace Feedle.Data
{
    public class InMemoryNewsService : INewsService
    {
        private string postFile = "posts.json";
        private IList<Post> posts;

        public InMemoryNewsService()
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
                    Content =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
                    AuthorUserName = "bob the spammer.",
                    Comments = new List<Comment>()
                },
                new Post
                {
                    Title = "dafadajkbjadf",
                    Content =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
                    AuthorUserName = "bob the spammer.",
                    Comments = new List<Comment>()
                },
                new Post
                {
                    Title = "c",
                    Content =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
                    AuthorUserName = "bob the spammer.",
                    Comments = new List<Comment>()
                },
                new Post
                {
                    Title = "e",
                    Content =
                        "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum",
                    AuthorUserName = "bob the spammer.",
                    Comments = new List<Comment>()
                }
            };
            this.posts = posts;
        }

        private void WritePostsToFile()
        {
            string productAsJson = JsonSerializer.Serialize(posts);
            File.WriteAllText(postFile, productAsJson);
        }


        public async Task<bool> AddPostAsync(Post post)
        {
            this.posts.Add(post);
            WritePostsToFile();
            return true;
        }

        public async Task<IList<Post>> GetAllNews()
        {
            return posts;
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            for (int i = 0; i < posts.Count; i++)
            {
                if (posts[i].Id == post.Id)
                {
                    posts[i] = post;
                    WritePostsToFile();
                    break;
                }
            }
            throw new NotImplementedException();
            
        }

        public Task<List<Post>> GetPostsForRegisteredUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CommentPost(Comment comment, int postId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeletePost(int postId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteComment(Post post, int commentId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> IsPostThumbUpByUser(Post post, User user)
        {
            //TODO: do this
            return false;
        }

        public async Task<bool> IsPostThumbDownByUser(Post post, User user)
        {
            //TODO: do this
            return false;
        }

        public Task<bool> DeleteComment(int postId, int commentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeletePostReaction(int postReactionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MakePostReaction(PostReaction postReaction)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePostReaction(PostReaction postReaction)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostById(int posId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}