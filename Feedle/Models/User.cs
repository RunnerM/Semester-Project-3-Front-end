﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
    }
}