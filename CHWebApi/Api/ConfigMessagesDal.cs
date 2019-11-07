using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHWebApi.Api
{
    public class ConfigMessagesDal : IMessagesDal
    {
        private readonly IMessageConfig _configuration;
        private readonly IMessageFactory _messageFactory;

        public ConfigMessagesDal( IMessageConfig configuration, IMessageFactory messageFactory )
        {
            _configuration = configuration;
            _messageFactory = messageFactory;
        }

        public async Task<IEnumerable<IMessage>> Retrieve()
        {
            var message = _messageFactory.Create();
            message.Text = _configuration.MessageText;
            return new[] { message };
        }

        public async Task<IMessage> Retrieve( long id )
        {
            var message = _messageFactory.Create();
            message.Id = id;
            message.Text = _configuration.MessageText;
            return message;
        }

        public async Task<IMessage> Create( IMessage message )
        {
            throw new NotImplementedException();
        }

        public async Task<IMessage> Update( IMessage message )
        {
            throw new NotImplementedException();
        }

        public async Task Delete( long id )
        {
            throw new NotImplementedException();
        }
    }
}
