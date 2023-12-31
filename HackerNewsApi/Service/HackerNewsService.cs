﻿using HackerNewsApi.dbo;
using HackerNewsApi.Repository.RepoApi;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Writers;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNewsApi.Service
{
    /// <summary>
    /// Create a service class to get all News and store in Mamory cache
    /// </summary>
    public class HackerNewsService : IHackerNewsService
    {
        readonly IHackerNewsRepository _repo;
        readonly IMemoryCache _cacheService;

        /// <summary>
        /// create a constructor and inject dependency 
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="cacheService"></param>
        public HackerNewsService(IHackerNewsRepository repository, IMemoryCache cacheService)
        {
            _repo = repository;
            _cacheService = cacheService;
        }


        /// <summary>
        /// with the help of repository object fetch the all news ids 
        /// pass the ids one by one to GetNewestStoriesByIdAsync()
        /// </summary>
        /// <returns></returns>
        public async Task<List<NewsStories>> GetNewestStoriesAsync()
        {
            List<NewsStories> newNews = new List<NewsStories>();
            try
            {
                var news = await _repo.GetAllNews();
                if (news.IsSuccessStatusCode)
                {
                    var NewsResponse = news.Content.ReadAsStringAsync().Result;
                    var allNewsIds = JsonConvert.DeserializeObject<List<int>>(NewsResponse);

                    var tasks = allNewsIds.Select(GetNewestStoriesByIdAsync);
                    newNews = (await Task.WhenAll(tasks)).ToList();
                }

                return newNews;
            }
            catch (Exception ex)
            {
                // Handle and log exceptions here
                return newNews;
            }
        }


        /// <summary>
        /// Get news base on Id and store in IMemory
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public async Task<NewsStories> GetNewestStoriesByIdAsync(int newsId)
        {
            try
            {

                return await _cacheService.GetOrCreateAsync<NewsStories>(newsId,
                    async cacheEntry =>
                    {
                        NewsStories news = new NewsStories();

                        var response = await _repo.GetNewsById(newsId);
                        if (response.IsSuccessStatusCode)
                        {
                            var storyResponse = response.Content.ReadAsStringAsync().Result;
                            return JsonConvert.DeserializeObject<NewsStories>(storyResponse);
                        }

                        return news;
                    });
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
