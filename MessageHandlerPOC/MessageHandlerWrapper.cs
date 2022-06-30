using MessageHandlerPOC.Interfaces;
using Newtonsoft.Json;

namespace MessageHandlerPOC
{
    public class MessageHandlerWrapper<TContent> : IMessageHandler 
    {
        private readonly IMessageHandler<TContent> _handler;

        public MessageHandlerWrapper(IMessageHandler<TContent> handler)
        {
            _handler = handler;
        }

        public void HandleMessage(string message)
        {
            var content = JsonConvert.DeserializeObject<TContent>(message);
            _handler.HandleMessage(new Message<TContent>(content));
        }
    }
}
