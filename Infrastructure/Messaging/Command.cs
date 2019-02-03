using System;

namespace BlackYellow.Infrastructure.Messaging
{
    public class Command : Message
    {
      public Command(Guid messageId, MessageTypes messageType) : base(messageId, messageType) { }
    }
}
