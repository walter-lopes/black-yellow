using ShopManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.UnitTests.TestDataBuilders
{
    public class ProductBuilder
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }

        public ProductBuilder()
        {
            SetDefaults();
        }

        public Product Build()
        {
            return new Product(this.Id, this.Name, this.Price);
        }

        private void SetDefaults()
        {
            this.Id = Guid.NewGuid();
            this.Name = "Nike 90 air max";
            this.Price = 200;
        }
    }
}
