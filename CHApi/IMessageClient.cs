using System.Collections.Generic;
using System.Threading.Tasks;

namespace CHApi
{
    public interface IMessageClient
    {
        Task<IEnumerable<Message>> Get();
        Task<Message> Get( long id );
        Task Post( Message message );
        Task Put( Message message );
        Task Delete( long id );
    }
}
