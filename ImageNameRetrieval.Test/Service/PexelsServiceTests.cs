using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

using Moq;
using Moq.Protected;
using Xunit;

using ImageNameRetrieval.Service;
using ImageNameRetrieval.Service.Models;

namespace ImageNameRetrieval.Test.Service
{
    public class PexelsServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandler;
        private readonly PexelsService _pexelsService;

        public PexelsServiceTests()
        {
            _httpMessageHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_httpMessageHandler.Object);
            _pexelsService = new PexelsService(httpClient);
        }

        [Fact] 
        public async Task GetImages_ValidResponse_APIDataReturn()
        {
            // Arrange
            var mockResponse = new Pexels
            {
                TotalResults = 1,
                Photos = new List<Photo>
                {
                    new Photo { Id = 1, Alt = "Please No AI Images" }
                }
            };

            _httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(mockResponse)
                });

            // Act
            var result = await _pexelsService.GetImages("test", 1);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Photos);
            Assert.Equal("Please No AI Images", result.Photos.First().Alt);
        }

        [Fact]
        public async Task GetImages_EmptyResponse_APIDataFail()
        {
            // Arrange
            _httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                });

            var result = await _pexelsService.GetImages("test", 1);

            Assert.NotNull(result);
            Assert.NotNull(result.Photos); // Ensure Photos is initialized
            Assert.Empty(result.Photos); // Expect Photos to be empty
        }
    }
}
