# Hacker News API

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-6.0-blue)
![Author](https://img.shields.io/badge/Author-Vaibhav%20Agrawal-green)

Hacker News API is a web application built with ASP.NET Core 6.0 that fetches data from the Hacker News API and displays it to the users.

## Features

- Fetch and display the latest stories from Hacker News API.
- Built using ASP.NET Core 6.0 for high performance and scalability.

## Installation

To run this application locally, make sure you have the following prerequisites installed:

- [.NET Core 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

Follow these steps to get the application up and running:

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/hacker-news-api.git

## Application Flow

 1. Read the data of news stories from the Hacker News API, code snippet as below for reference:
    return await _httpClient.GetAsync(GetUrls.getNewsUrl);

 2. Store the data read above to memory cache, code snippet as below for reference:
    return await _cacheService.GetOrCreateAsync<NewsStories>(newsId,
    async cacheEntry =>

 3. Display the news stories through the API controller
  

  
