using CHWebApi.Api;
using System;
using Xunit;

namespace CHWebApiTests
{
    public class MessageFactoryTests
    {
        [Fact]
        public void CreateMessage()
        {
            var factory = new MessageFactory();
            
            var message = factory.Create();

            Assert.NotNull( message );
        }
    }
}
