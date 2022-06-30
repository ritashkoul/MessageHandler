using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageHandlerPOC.Interfaces
{
    public interface IMessageHandler
    {
        void HandleMessage(string message);
    }

    public interface IMessageHandler<TContent>
    {
        void HandleMessage(Message<TContent> message);
    }
}
