using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace StudyFriendTests
{
    public class AuthTests
    : IClassFixture<WebApplicationFactory<StudyFriend.Startup>>
    {
        private readonly WebApplicationFactory<StudyFriend.Startup> _factory;

        public AuthTests(WebApplicationFactory<StudyFriend.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/Topics")]
        [InlineData("/Questions")]
        [InlineData("/Answers")]
        public async Task Get_ProtectedEndpointRedirectsUnauthenticatedUser(string url)
        {
            // Arrange
            var client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("/Identity/Account/Login",
                response.Headers.Location.LocalPath);
        }
    }
}
