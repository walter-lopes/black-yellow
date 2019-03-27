using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Domain
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Customer Customer { get; private set; }
        public IEnumerable<OrderItem> OrderItems { get; private set; }

        public double Total
        {
            get
            {
                return this.OrderItems.Sum(p => p.SubTotal);
            }
        }

        public Order(Customer customer, IEnumerable<OrderItem> orderItems)
        {
            this.Customer = customer;
            this.OrderItems = orderItems;
        }
    }
}
