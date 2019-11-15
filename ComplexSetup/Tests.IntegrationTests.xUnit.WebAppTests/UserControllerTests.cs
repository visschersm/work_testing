using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using TestWebApp;
using Xunit;

namespace Tests.IntegrationTests.xUnit.WebAppTests
{
    public class UserControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public UserControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/User")]
        public async Task GetAsync_EndpointReturnSuccess(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
