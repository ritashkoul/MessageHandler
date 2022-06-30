using MessageHandlerPOC.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageHandlerPOC
{
    public class MessageHandler : IMessageHandler
    {
        private readonly IMessageHandlerFactory _messageHandlerFactory;

        public MessageHandler(IMessageHandlerFactory messageHandlerFactory)
        {
            _messageHandlerFactory = messageHandlerFactory;
        }

        public void HandleMessage(string message)
        {
            JObject parsedData = JObject.Parse(message);
            string type = parsedData["Type"].ToString();

            var handler = _messageHandlerFactory.GetHandler(type);
            handler.HandleMessage(message);
        }
    }
}
