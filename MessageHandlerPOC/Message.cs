using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageHandlerPOC
{
    public class Message<TContent>
    {
        public Message(TContent content)
        {
            Content = content;
        }

        public TContent Content { get; }
    }
}
