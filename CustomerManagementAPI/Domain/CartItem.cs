using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackYellow.CustomerManagementAPI.Domain
{
    public class CartItem
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice => Quantity * Price;


        public CartItem(Guid productId, string productName, decimal price, int quantity)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            SetQuantity(quantity);
            SetPrice(price);
        }

        public void SetQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new Exception();
            this.Quantity = quantity;
        }

        public void IncreaseQuantity(int quantity)
        {
            this.Quantity += quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            this.Quantity -= quantity;
        }

        public void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new Exception();
            this.Price = price;
        }
    }
}
