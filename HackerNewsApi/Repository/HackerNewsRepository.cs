using HackerNewsApi.Repository.RepoApi;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsApi.Repository
{
    public class HackerNewsRepository : IHackerNewsRepository
    {
        readonly HttpClient _httpClient;

        public HackerNewsRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<HttpResponseMessage> GetAllNews()
        {
            return await _httpClient.GetAsync(GetUrls.getNewsUrl);
        }

        public async Task<HttpResponseMessage> GetNewsById(int id)
        {
            return await _httpClient.GetAsync(GetUrls.getUrlById + id + ".json");

        }
    }
}
