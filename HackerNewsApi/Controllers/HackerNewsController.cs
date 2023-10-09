using HackerNewsApi.dbo;
using HackerNewsApi.Repository.RepoApi;
using HackerNewsApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackerNewsController : ControllerBase
    {
        private readonly IHackerNewsService _service;

        /// <summary>
        /// create a dependency injection to invoke service object
        /// </summary>
        /// <param name="service"></param>
        public HackerNewsController(IHackerNewsService service)
        {
            _service = service;
        }

        /// <summary>
        /// calling service method for fetching the Hacker news data
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "NewestStories")]
        public async Task<List<NewsStories>> GetNewestStories()
        {
            return await _service.GetNewestStoriesAsync();
        }
    }
}
