using MessageHandlerPOC.Interfaces;
using MessageHandlerPOC.Payloads;

namespace MessageHandlerPOC.Handlers
{
    public class DummyHandlerTwo : IMessageHandler<DummyMessageTwo>
    {
        public void HandleMessage(Message<DummyMessageTwo> message)
        {
            
        }
    }
}
