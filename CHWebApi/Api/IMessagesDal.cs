using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHWebApi.Api
{
    public interface IMessagesDal
    {
        Task<IEnumerable<IMessage>> Retrieve();
        Task<IMessage> Retrieve( long id );
        Task<IMessage> Create( IMessage message );
        Task<IMessage> Update( IMessage message );
        Task Delete( long id );
    }
}
