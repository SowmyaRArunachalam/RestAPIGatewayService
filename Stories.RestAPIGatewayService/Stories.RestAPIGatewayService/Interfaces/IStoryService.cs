using Stories.RestAPIGatewayService.Models;

namespace Stories.RestAPIGatewayService.Interfaces
{
    public interface IStoryService
    {
        Task<string> GetBestStoryItemNumbers();
        Task<string> GetStoryDetail(int item);
        List<string> populateStoryIds(string[] results);
        List<Story> populateStoryDetail(string[] storyDetailArray, List<Story> storiesList);
    }
}
