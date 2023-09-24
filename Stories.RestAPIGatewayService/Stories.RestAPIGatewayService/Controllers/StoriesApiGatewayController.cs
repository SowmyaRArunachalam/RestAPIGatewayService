using Microsoft.AspNetCore.Mvc;
using Stories.RestAPIGatewayService.Interfaces;
using Stories.RestAPIGatewayService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//Sowmya Arunachalam Rest APIGateway service
namespace Stories.RestAPIGatewayService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoriesApiGatewayController : ControllerBase
    {
        private readonly IStoryService _iStoryService;
        
        public StoriesApiGatewayController(IStoryService _storyService)
        {
            _iStoryService = _storyService;
        }

        // Get Best story Ids
        [HttpGet("~/apigateway/BestStoryNumbers")]
        public async Task<string> GetBestStoryItemNumbersFromAPI()
        {
            return await _iStoryService.GetBestStoryItemNumbers();
        }

        // Get story details ordered in descnding order of score
        [HttpGet("~/apigateway/BestStories/{number}")]
        public async Task<List<Story>> GetBestStoriesFromAPI([FromRoute] int number)
        {
            string[] results = await Task.WhenAll(_iStoryService.GetBestStoryItemNumbers());
            List<String> storyNumbersList = _iStoryService.populateStoryIds(results);

            List<Story> storiesList = new List<Story>();
            foreach (string item in storyNumbersList)
            {
                string[] storyDetailArray = await Task.WhenAll(_iStoryService.GetStoryDetail(Convert.ToInt32(item)));//Not using ConfigureAwait as there is no UI
                storiesList = _iStoryService.populateStoryDetail(storyDetailArray,storiesList); 
            }
            return storiesList.OrderByDescending(o => o.score).ToList<Story>().GetRange(0,number);
        }
    }
}
