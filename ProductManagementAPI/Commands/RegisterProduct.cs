using BlackYellow.Infrastructure.Messaging;

namespace ProductManagementAPI.Commands
{
    public class RegisterProduct : Command
    {      
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid OwnerId { get; set; }

        public RegisterProduct(Guid messageId, Guid id, string name, string description, Guid ownerId)
            : base (messageId, MessageTypes.ProductRegistered)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.OwnerId = ownerId;
        }
    }
}