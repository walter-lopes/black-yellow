using BlackYellow.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Infrastructure.Messaging
{
    public class Event : Message
    {
        public Event(Guid messageId, MessageTypes messageType) : base(messageId, messageType)
        {
        }
    }
}
