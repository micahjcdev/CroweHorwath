using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CHWebApi.Api;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CHWebApi.Controllers
{
    [Route( "api/v1/[controller]" )]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesDal _messagesDal;

        public MessagesController( IMessagesDal messagesDal )
        {
            _messagesDal = messagesDal;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<IEnumerable<IMessage>> Get()
        {
            return await _messagesDal.Retrieve();
        }

        // GET: api/Messages/5
        [HttpGet( "{id}", Name = "Get" )]
        public async Task<IMessage> Get( int id )
        {
            return await _messagesDal.Retrieve( id );
        }

        // POST: api/Messages
        [HttpPost]
        public async Task<IMessage> Post( [FromBody] IMessage value )
        {
            return value;
        }

        // PUT: api/Messages/5
        [HttpPut( "{id}" )]
        public async Task<IMessage> Put( [FromBody] IMessage value )
        {
            return value;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete( "{id}" )]
        public async Task Delete( int id )
        {
        }
    }
}
