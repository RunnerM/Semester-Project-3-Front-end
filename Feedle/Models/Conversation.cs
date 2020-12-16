using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Feedle.Models
{
    public class Conversation
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; }

        public Conversation()
        {
            Messages = new List<Message>();
        }
    }
}