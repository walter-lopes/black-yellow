using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Domain
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public IEnumerable<OrderItem> OrderItems { get; private set; }
        public StatusOrder Status { get; private set; }

        public double Total
        {
            get
            {
                return this.OrderItems.Sum(p => p.SubTotal);
            }
        }

        public Order(Guid customerId, IEnumerable<OrderItem> orderItems)
        {
            this.CustomerId = customerId;
            this.OrderItems = orderItems;
            this.Status = StatusOrder.Pending;
        }
       

        public void Complete()
        {
            if (this.Status != StatusOrder.Pending)
                throw new Exception();

            this.Status = StatusOrder.Completed;
        }

        public void Cancel()
        {
            if (this.Status != StatusOrder.Completed)
                throw new Exception();

            this.Status = StatusOrder.Canceled;
        }
    }
}
