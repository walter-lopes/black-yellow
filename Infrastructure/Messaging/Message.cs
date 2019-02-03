using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Infrastructure.Messaging
{
    public class Message
    {
        public readonly Guid MessageId;
        public readonly MessageTypes MessageType;

        public Message(Guid messageId, MessageTypes messageType)
        {
            this.MessageId = messageId;
            this.MessageType = messageType;
        }
    }
}
