using ShopManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.UnitTests.TestDataBuilders
{
    public class OrderItemBuilder
    {

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; set; }

        public decimal SubTotal
        {
            get
            {
                return this.Price * this.Quantity;
            }
        }

        public OrderItemBuilder()
        {
            SetDefaults();
        }

        public OrderItem Build()
        {
            return new OrderItem(this.Id, this.Name, this.Price, this.Quantity);
        }

        private void SetDefaults()
        {
            this.Id = Guid.NewGuid();
            this.Name = "Nike 90 air max";
            this.Price = 200;
            this.Quantity = 2;
        }
    }
}
