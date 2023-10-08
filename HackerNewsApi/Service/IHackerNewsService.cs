using HackerNewsApi.dbo;

namespace HackerNewsApi.Service
{
    public interface IHackerNewsService
    {

        Task<List<NewsStories>> GetNewestStoriesAsync();
        Task<NewsStories> GetNewestStoriesByIdAsync(int id);
    }
}
