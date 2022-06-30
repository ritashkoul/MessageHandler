using MessageHandlerPOC.Interfaces;
using MessageHandlerPOC.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageHandlerPOC.Handlers
{
    public class DummyHandlerOne : IMessageHandler<DummyMessageOne>
    {
        private readonly IBL _bl;
        public DummyHandlerOne(IBL bL)
        {
            _bl = bL;
        }

        public void HandleMessage(Message<DummyMessageOne> message)
        {
            _bl.Insert();
        }
    }
}
