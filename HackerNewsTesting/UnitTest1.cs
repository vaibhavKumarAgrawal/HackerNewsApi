using Xunit;
using Moq;
using HackerNewsApi.Repository;
using System.Net;

namespace HackerNewsTesting
{
    public class UnitTest1
    {
        [Fact]
        public async Task GetAllNews_ReturnsHttpResponseMessage()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            var httpClient = new HttpClient();
            var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            mockHttpClientFactory.Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            var hackerNewsRepository = new HackerNewsRepository(httpClient);

            // Act
            var result = await hackerNewsRepository.GetAllNews();

            // Assert
            Assert.IsType<HttpResponseMessage>(result);
        }

        [Fact]
        public async Task GetNewsById_ReturnsHttpResponseMessage()
        {
            // Arrange
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            var httpClient = new HttpClient();
            var responseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);

            mockHttpClientFactory.Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            var hackerNewsRepository = new HackerNewsRepository(httpClient);

            // Act
            var result = await hackerNewsRepository.GetNewsById(37791002);

            // Assert
            Assert.IsType<HttpResponseMessage>(result);
        }
    }
}