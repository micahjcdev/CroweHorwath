using RestSharp;

namespace CHApi
{
    public interface IRestClientFactory
    {
        IRestClient GetRestClient();

        IRestRequest GetRestRequest( string resource );
    }
}
