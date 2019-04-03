using CustomerManagment.UnitTests.TestDataBuilders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CustomerManagment.UnitTests.DomainTests
{
    public class CartItemTest
    {
        [Fact]
        public void CartItem_Should_Has_Created()
        {
            CartItemBuilder sut = new CartItemBuilder();
            var cartItem = sut.Build();

            Assert.Equal(sut.ProductName, cartItem.ProductName);
            Assert.Equal(sut.ProductId, cartItem.ProductId);
            Assert.Equal(sut.Price, cartItem.Price);
            Assert.Equal(sut.Quantity, cartItem.Quantity);
            Assert.Equal(sut.TotalPrice, cartItem.TotalPrice);


        }
    }
}
