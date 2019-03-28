using System;

namespace ProductManagementAPI.Models
{
    public class Product
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity {get; set;}
    }
}