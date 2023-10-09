using HackerNewsApi.Repository.RepoApi;
using Microsoft.AspNetCore.Mvc;

namespace HackerNewsApi.Repository
{
    public class HackerNewsRepository : IHackerNewsRepository
    {
        readonly HttpClient _httpClient;

        /// <summary>
        /// create a constructor and call httpclient request for fetching the data from Hacker news API
        /// </summary>
        /// <param name="httpClient"></param>
        public HackerNewsRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Use httpclient and get news ids
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetAllNews()
        {
            return await _httpClient.GetAsync(GetUrls.getNewsUrl);
        }

        /// <summary>
        /// Use httpclient and pass Id for fetching one by one record 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetNewsById(int id)
        {
            return await _httpClient.GetAsync(GetUrls.getUrlById + id + ".json");

        }
    }
}
