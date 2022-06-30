using MessageHandlerPOC.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageHandlerPOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageHandlerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<MessageHandlerController> _logger;
        private readonly IMessageHandler _handler;

        public MessageHandlerController(ILogger<MessageHandlerController> logger, 
            IMessageHandler handler)
        {
            _logger = logger;
            _handler = handler;
        }

        [HttpGet]
        public void Get()
        {
            //string message = @"{'Type': 'DummyMessageOne', 'MessageOneId': 1}";
            string message = @"{'Type': 'DummyMessageTwo', 'MessageTwoId': 1}";
            _handler.HandleMessage(message);
        }
    }
}
