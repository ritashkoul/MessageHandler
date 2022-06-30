using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageHandlerPOC.Interfaces
{
    public interface IMessageHandlerFactory
    {
        IMessageHandler GetHandler(string type);
    }
}
