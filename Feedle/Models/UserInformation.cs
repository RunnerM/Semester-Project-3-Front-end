using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using FeedleDataTier.Models;

namespace Feedle.Models
{
    public class UserInformation
    {
        [Key] [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("userName")] public string UserName { get; set; }
        [JsonPropertyName("userSubscriptions")] public List<UserSubscription> UserSubscriptions { get; set; }
        [JsonPropertyName("userFriends")] public List<UserFriend> UserFriends { get; set; }
        [JsonPropertyName("userImageSrc")] public string UserImageSrc { get; set; }
    }
}