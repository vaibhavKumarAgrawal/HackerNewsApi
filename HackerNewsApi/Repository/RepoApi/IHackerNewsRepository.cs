namespace HackerNewsApi.Repository.RepoApi
{
    public interface IHackerNewsRepository
    {
        Task<HttpResponseMessage> GetAllNews();

        Task<HttpResponseMessage> GetNewsById(int id);
    }
}
