using CHApi;

namespace CHConsoleApplication.MyApi
{
    public class CHWebApiConfig : IClientConfig
    {
        public string BaseUrl { get; set; }
        public string MessagesApi { get; set; }
    }
}
