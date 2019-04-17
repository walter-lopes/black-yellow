using BlackYellow.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagementEventHandler.Events
{
    public class CustomerRegistered : Event
    {
        public readonly string CustomerId;
        public readonly string Name;
        public readonly string Email;

        public CustomerRegistered(Guid messageId, string customerId, string name, string email) : base(messageId, MessageTypes.CustomerRegistered)
        {
            CustomerId = customerId;
            Name = name;
            Email = email;
        }
    }
}
