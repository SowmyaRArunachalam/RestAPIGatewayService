using Newtonsoft.Json;
using Stories.RestAPIGatewayService.Models;
using Stories.RestAPIGatewayService.Helpers;
using Stories.RestAPIGatewayService.Interfaces;

namespace Stories.RestAPIGatewayService.Services
{
    public class StoryService : IStoryService
    {        
        private readonly HttpClient _httpClient;

        public StoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://hacker-news.firebaseio.com");
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("Application/json"));
        }
        public async Task<string> GetBestStoryItemNumbers()
        {            
            HttpResponseMessage response =   _httpClient.GetAsync("/v0/beststories.json").Result;
            response.EnsureSuccessStatusCode();
            
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> GetStoryDetail(int item)
        {       
            HttpResponseMessage response = _httpClient.GetAsync("/v0/item/"+item+".json").Result;
            response.EnsureSuccessStatusCode();
            
            return await response.Content.ReadAsStringAsync();
        }
        public List<string> populateStoryIds(string[] results)
        {
            List<String> storyNumbersList  = String.Join(",", results).Replace("[", "").Replace("]", "").Split(",").ToList();
            return  storyNumbersList;
        }
        public List<Story> populateStoryDetail (string[] storyDetailArray, List<Story> storiesList)
        {
            var jsonResult = JsonConvert.DeserializeObject(String.Join(",", storyDetailArray));
            var storyDetail = JsonConvert.DeserializeObject<Story>(jsonResult.ToString());

            storyDetail.time = DateTimeExtensions.FromUnixTimeStampToDateTime(storyDetail.time).ToString();
            storiesList.Add(storyDetail);

            return storiesList;
        }
    }
}


