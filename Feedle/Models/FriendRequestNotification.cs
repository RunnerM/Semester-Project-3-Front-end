using System.Text.Json.Serialization;

namespace Feedle.Models
{
    public class FriendRequestNotification
    {
        [JsonPropertyName("friendRequestId")]
        public int FriendRequestId { get; set; }
        
        [JsonPropertyName("creatorId")]
        public int CreatorId { get; set; }
        
        [JsonPropertyName("userId")] public int UserId { get; set; }
        [JsonPropertyName("potentialFriendUserId")] 
        public int PotentialFriendUserId { get; set; }
        [JsonPropertyName("creatorUserName")]
        public string CreatorUserName { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("potentialFriendUserName")]
        public string PotentialFriendUserName { get; set; }
    }
}