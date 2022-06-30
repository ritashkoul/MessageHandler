using MessageHandlerPOC.Interfaces;
using System;
using System.Collections.Generic;

namespace MessageHandlerPOC
{
    public class MessageHandlerFactory : IMessageHandlerFactory
    {
        private readonly Dictionary<string, Func<IMessageHandler>> _messageHandlers
            = new Dictionary<string, Func<IMessageHandler>>(StringComparer.OrdinalIgnoreCase);

        public void RegisterHandler(string messageType, Func<IMessageHandler> getHandlerFunction)
        {
            _messageHandlers[messageType] = getHandlerFunction;
        }

        public IMessageHandler GetHandler(string messageType)
        {
            if (_messageHandlers.ContainsKey(messageType))
                return _messageHandlers[messageType]();

            return null;
        }
    }
}
