namespace CHWebApi.Api
{
    public class Message : IMessage
    {
        public long Id { get; set; }
        public string Text { get; set; }
    }
}
