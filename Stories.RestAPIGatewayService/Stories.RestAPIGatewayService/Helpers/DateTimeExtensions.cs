using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Stories.RestAPIGatewayService.Helpers
{
        public static class DateTimeExtensions
        {
            public static string FromUnixTimeStampToDateTime(this string unixTimeStamp)
            {
                 DateTime dt= DateTimeOffset.FromUnixTimeSeconds(long.Parse(unixTimeStamp)).DateTime;
                 DateTimeOffset localTimeAndOffset = new DateTimeOffset(dt, TimeZoneInfo.Local.GetUtcOffset(dt));
                 var str = JsonConvert.SerializeObject(localTimeAndOffset);
                 return JsonConvert.DeserializeObject<string>(str);
            }
        }    
}
