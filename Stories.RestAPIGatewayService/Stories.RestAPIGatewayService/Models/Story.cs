using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Stories.RestAPIGatewayService.Models
{
    public class Story
    {        
        public string title { get; set; }

        [JsonPropertyName("uri")]
        public string url { get; set; }
        [JsonPropertyName("postedBy")]
        public string by { get; set; }
        //[JsonConverter(typeof(JavaScriptDateTimeConverter))]
        public string time { get; set; }       
        public int score { get; set; }
        
        [JsonPropertyName ("commentCount")]
        public int descendants { get; set; }
    }
}
