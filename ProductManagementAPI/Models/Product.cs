namespace ProductManagementAPI.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid OwnerId { get; set; }
    }
}