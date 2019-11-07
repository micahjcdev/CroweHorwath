using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHApi
{
    public class MessageClient : IMessageClient
    {
        private readonly IRestClientFactory _restClientFactory;
        private readonly IClientConfig _config;
        private readonly IRestClient _client;

        public MessageClient( IClientConfig config, IRestClientFactory restClientFactory )
        {
            _restClientFactory = restClientFactory;
            _config = config;
            _client = restClientFactory.GetRestClient();
        }

        public async Task<IEnumerable<Message>> Get()
        {
            var request = _restClientFactory.GetRestRequest( _config.MessagesApi );

            var response = await _client.ExecuteTaskAsync<List<Message>>( request, Method.GET );

            return response.Data;
        }

        public async Task<Message> Get( long id )
        {
            var request = _restClientFactory.GetRestRequest( $"{_config.MessagesApi}/{id}" );

            var response = await _client.ExecuteTaskAsync<Message>( request, Method.GET );

            return response.Data;
        }

        public Task Post( Message message )
        {
            throw new NotImplementedException();
        }

        public Task Put( Message message )
        {
            throw new NotImplementedException();
        }

        public Task Delete( long id )
        {
            throw new NotImplementedException();
        }
    }
}
