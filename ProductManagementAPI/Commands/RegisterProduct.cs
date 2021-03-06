using System;
using BlackYellow.Infrastructure.Messaging;

namespace ProductManagementAPI.Commands
{
    public class RegisterProduct : Command
    {      
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public string Description { get; set; }

        public int  Quantity { get; set; }

        public double Price { get; set; }

        public RegisterProduct(Guid messageId, Guid id, string name, string description, Guid ownerId)
            : base (messageId, MessageTypes.RegisterProduct)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description; 
        }
    }
}