using BlackYellow.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Commands
{
    public class AddOrderItem : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public AddOrderItem(Guid messageId, MessageTypes messageType) : base(messageId, messageType)
        {
        }
    }
}
