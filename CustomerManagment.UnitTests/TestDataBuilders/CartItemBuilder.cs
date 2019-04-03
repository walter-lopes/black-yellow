using BlackYellow.CustomerManagementAPI.Domain;
using CustomerManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagment.UnitTests.TestDataBuilders
{
    public class CartItemBuilder
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalPrice { get; private set; }

        public CartItemBuilder()
        {
            SetDefaults();
        }

        public CartItem Build()
        {
            return new CartItem(ProductId, ProductName, Price, Quantity);
        }

        public IEnumerable<CartItem> BuildList()
        {
            return new List<CartItem>
            {
                new CartItem(ProductId, ProductName, Price, Quantity),
                new CartItem(ProductId, ProductName, Price, Quantity)
            };
        }


        private void SetDefaults()
        {
            this.ProductId = new Guid();
            this.ProductName = "X-BOX 360";
            this.Price = 100;
            this.Quantity = 2;
            TotalPrice = 200;
        }
    }
}
