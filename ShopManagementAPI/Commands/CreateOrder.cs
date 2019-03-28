using BlackYellow.Infrastructure.Messaging;
using System;

namespace ShopManagementAPI.Commands
{
    public class CreateOrder : Command
    {
        public CreateOrder(Guid messageId, MessageTypes messageType) : base(messageId, messageType)
        {
        }
    }
}
