using ShopManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopManagement.UnitTests.TestDataBuilders
{
    public class OrderBuilder
    {
        public Guid Id { get; private set; }
        public CustomerBuilder Customer { get; private set; }

        public IEnumerable<OrderItemBuilder> OrderItems { get; private set; }

        public double Total
        {
            get
            {
                return this.OrderItems.Sum(p => p.Price);
            }
        }

        public OrderBuilder()
        {
            SetDefaults();
        }


        public Order Build()
        {
            Customer customer = Customer.Build();
            IEnumerable<OrderItem> products = OrderItems.Select(p => p.Build());
            return new Order(customer.Id, products);
        }

        private void SetDefaults()
        {
            this.Id = Guid.NewGuid();
            this.Customer = new CustomerBuilder();
            this.OrderItems = new List<OrderItemBuilder> { new OrderItemBuilder() };
        }
    }
}
