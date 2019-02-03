using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlackYellow.Infrastructure.Messaging
{
    public interface IMessagePublisher
    {
        Task PublishMessageAsync(MessageTypes messageType, object message, string routingKey);
    }
}
