using BlackYellow.Infrastructure.Messaging;
using ShopManagementAPI.Domain;
using System;
using System.Collections.Generic;

namespace ShopManagementAPI.Commands
{
    public class CreateOrder : Command
    {
        public Guid CustomerId { get; set; }
        public Guid Id { get; set; }
        public CreateOrder(Guid messageId, MessageTypes messageType) : base(messageId, messageType)
        {
        }
    }
}
