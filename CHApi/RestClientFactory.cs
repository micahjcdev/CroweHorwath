using RestSharp;

namespace CHApi
{
    public class RestClientFactory : IRestClientFactory
    {
        protected IClientConfig Config { get; private set; }

        public RestClientFactory( IClientConfig config )
        {
            Config = config;
        }

        public IRestClient GetRestClient()
        {
            var client = new RestClient( Config.BaseUrl );
            // Add authentication as needed
            return client;
        }

        public IRestRequest GetRestRequest( string resource )
        {
            var request = new RestRequest( resource );
            return request;
        }
    }
}
