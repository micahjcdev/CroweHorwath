using CHApi;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace CHApiTests
{
    public class MessageClientTests
    {
        [Fact]
        public async void GetAllTest()
        {
            var config = new ClientConfig { BaseUrl = "url", MessagesApi = "Messages" };

            var client = MockRestClient<List<Message>>( HttpStatusCode.OK, "[]" );
            var request = new Mock<IRestRequest>();

            var factory = new Mock<IRestClientFactory>();
            factory.Setup( x => x.GetRestClient() ).Returns( client );
            factory.Setup( x => x.GetRestRequest( It.IsAny<string>() ) ).Returns( request.Object );

            var messageClient = new MessageClient( config, factory.Object );

            var messages = await messageClient.Get();

             Assert.NotNull( messages );
        }

        [Fact]
        public async void GetTest()
        {
            var config = new ClientConfig { BaseUrl = "url", MessagesApi = "Messages" };

            var client = MockRestClient<Message>( HttpStatusCode.OK, "{}" );
            var request = new Mock<IRestRequest>();

            var factory = new Mock<IRestClientFactory>();
            factory.Setup( x => x.GetRestClient() ).Returns( client );
            factory.Setup( x => x.GetRestRequest( It.IsAny<string>() ) ).Returns( request.Object );

            var messageClient = new MessageClient( config, factory.Object );

            var messages = await messageClient.Get(1);

            Assert.NotNull( messages );
        }

        public static IRestClient MockRestClient<T>( HttpStatusCode httpStatusCode, string json ) where T : new()
        {
            var data = JsonConvert.DeserializeObject<T>( json );
            var response = new Mock<IRestResponse<T>>();
            response.Setup( _ => _.StatusCode ).Returns( httpStatusCode );
            response.Setup( _ => _.Data ).Returns( data );

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
                .Setup( x => x.ExecuteTaskAsync<T>( It.IsAny<IRestRequest>(), Method.GET ) )
                .ReturnsAsync( response.Object );
            return mockIRestClient.Object;
        }
    }
}
