namespace ProductManagementAPI.Events
{
    public class ProductRegistered
    {
         public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid OwnerId { get; set; }

        public ProductRegistered(Guid messageId, Guid id, string name, string description, Guid ownerId)
            : base (messageId, MessageTypes.ProductRegistered)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.OwnerId = ownerId;
        }
    }
}