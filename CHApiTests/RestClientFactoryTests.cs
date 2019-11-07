using CHApi;
using System;
using Xunit;

namespace CHApiTests
{
    public class RestClientFactoryTests
    {
        [Fact]
        public void GetRestClient()
        {
            var config = new ClientConfig { BaseUrl = "url", MessagesApi = "Messages" };
            var factory = new RestClientFactory( config );
            var client = factory.GetRestClient();
            Assert.NotNull( client );
        }
    }
}
