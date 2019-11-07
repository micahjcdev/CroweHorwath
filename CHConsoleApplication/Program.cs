using CHApi;
using CHConsoleApplication.MyApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CHConsoleApplication
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;
        private static IConfigurationRoot _configuration;

        internal static void Main( string[] args )
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath( Directory.GetCurrentDirectory() )
             .AddJsonFile( "appsettings.json" );

            _configuration = builder.Build();            

            RegisterServices();

            Run().Wait();

            DisposeServices();
        }

        private async static Task Run()
        {
            var service = _serviceProvider.GetService<IMessageClient>();
            var messge = await service.Get( 0 );

            Console.WriteLine( messge.Text );
        }

        private static void RegisterServices()
        {
            // Disable ssl certificate check for self signed localhost certificate
            ServicePointManager.ServerCertificateValidationCallback += ( sender, certificate, chain, sslPolicyErrors ) => true;

            var services = new ServiceCollection();

            //services.Configure<CHWebApiConfig>( _configuration.GetSection( "CHWebApi" ) );            
            var cHWebApiConfig = _configuration.GetSection( "CHWebApi" ).Get<CHWebApiConfig>();
            services.AddSingleton<IClientConfig>( cHWebApiConfig );
            
            services.AddScoped<IRestClientFactory, RestClientFactory>();
            services.AddScoped<IMessageClient, MessageClient>();

            _serviceProvider = services.BuildServiceProvider();
        }

        private static void DisposeServices()
        {
            if ( _serviceProvider == null )
            {
                return;
            }
            if ( _serviceProvider is IDisposable )
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }
    }
}