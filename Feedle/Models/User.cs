using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FeedleDataTier.Models;

namespace Feedle.Models
{
    [Serializable]
    public class User
    {
        [Key] [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("username")] public string UserName { get; set; }
        [JsonPropertyName("password")] public string Password { get; set; }

        [JsonPropertyName("displayedUsername")]
        public string DisplayedUserName { get; set; }

        [JsonPropertyName("userPosts")] public List<Post> UserPosts { get; set; }

        [JsonPropertyName("userConversations")]
        public List<UserConversation> UserConversations { get; set; }
        [JsonPropertyName("securityLevel")] public int SecurityLevel { get; set; }
        [JsonPropertyName("userSubscriptions")]
        public List<UserSubscription> UserSubscriptions { get; set; }
        [JsonPropertyName("userFriends")]
        public List<UserFriend> UserFriends { get; set; }
        [JsonPropertyName("friendRequestNotifications")]
        public List<FriendRequestNotification> FriendRequestNotifications { get; set; }
        [JsonPropertyName("userImageSrc")]
        public string UserImageSrc { get; set; }


        public User()
        {
            this.UserConversations = new List<UserConversation>();
            this.UserSubscriptions = new List<UserSubscription>();
            this.FriendRequestNotifications = new List<FriendRequestNotification>();
            this.UserFriends = new List<UserFriend>();
            this.UserPosts = new List<Post>();
        }

        
    }
}