using System.Text.Json.Serialization;

namespace Feedle.Models
{
    public class PostReaction
    {
        [JsonPropertyName("postReactionId")]
        public int PostReactionId { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("postId")]
        public int PostId { get; set; }
    }
}