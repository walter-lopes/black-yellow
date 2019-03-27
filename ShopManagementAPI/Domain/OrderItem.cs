using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Domain
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public double SubTotal { get; private set; }

        public OrderItem(Guid id, string name, double price, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.SetPrice(price);
            this.SetQuantity(quantity);
            this.SubTotal = this.Quantity * this.Price;
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0) throw new Exception();

            this.Quantity = quantity;
        }

        public void SetPrice(double price)
        {
            if (price <= 0) throw new Exception();

            this.Price = price;
        }
    }
}
