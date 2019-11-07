using CHWebApi.Api;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CHWebApiTests
{
    public class ConfigMessagesDalTests
    {
        [Fact]
        public async void RetrieveAllTest()
        {
            var config = new MessageConfig();
            var factory = new MessageFactory();
            var cmd = new ConfigMessagesDal( config, factory );

            var messages = await cmd.Retrieve();

            Assert.NotNull( messages );
        }

        [Fact]
        public async void RetrieveTest()
        {
            var config = new MessageConfig();
            var factory = new MessageFactory();
            var cmd = new ConfigMessagesDal( config, factory );

            var message = await cmd.Retrieve(1);

            Assert.NotNull( message );
            Assert.Equal( 1, message.Id );
        }
    }
}
