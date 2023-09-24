using System.Text.Json.Serialization;

namespace Stories.RestAPIGatewayService.Models
{
    public class StoryId
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
    }
}
