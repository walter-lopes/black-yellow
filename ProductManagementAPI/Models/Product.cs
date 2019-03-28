using System;

namespace ProductManagementAPI.Models
{
    public class Product
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; set; }

        public double Price { get; private set; }

        public int Quantity {get; private set;}

        public Product(Guid id, string name, string description, double price, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.SetPrice(price);
            this.SetQuantity(quantity);
        }

        public void SetPrice(double price)
        {
            if (price <= 0)
                throw new Exception();
            this.Price = price;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new Exception();
            this.Quantity = quantity;
        }
    }
}