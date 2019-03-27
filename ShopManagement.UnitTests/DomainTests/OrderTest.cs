using ShopManagement.UnitTests.TestDataBuilders;
using ShopManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ShopManagement.UnitTests.DomainTests
{
    public class OrderTest
    {
        [Fact]
        public void Order_Should_Has_Customer_Product_And_Total()
        {
            OrderBuilder sut = new OrderBuilder();
            var order = sut.Build();

            Assert.Equal(sut.Customer.Name, order.Customer.Name);
            Assert.Equal(sut.Customer.Email, order.Customer.Email);
            Assert.Equal(sut.OrderItems.Count(), order.OrderItems.Count());
            Assert.Equal(sut.OrderItems.FirstOrDefault().Price, order.OrderItems.FirstOrDefault().Price);
            Assert.Equal(sut.Total, order.Total);
            Assert.Equal(StatusOrder.Pending, order.Status);
        }

        [Fact]
        public void Order_Should_Has_Completed_Status_When_Is_Completed()
        {
            OrderBuilder sut = new OrderBuilder();
            var order = sut.Build();

            order.Complete();

            Assert.Equal(StatusOrder.Completed, order.Status);
        }
    }
}
