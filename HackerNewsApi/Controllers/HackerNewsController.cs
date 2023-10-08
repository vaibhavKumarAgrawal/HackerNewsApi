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
        public HackerNewsController(IHackerNewsService service)
        {
            _service = service;
        }

        [HttpGet(Name = "NewestStories")]
        public async Task<List<NewsStories>> GetNewestStories()
        {
            return await _service.GetNewestStoriesAsync();
        }
    }
}
