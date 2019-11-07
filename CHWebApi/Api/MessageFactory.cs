namespace CHWebApi.Api
{
    public class MessageFactory : IMessageFactory
    {
        public IMessage Create()
        {
            return new Message();
        }
    }
}
