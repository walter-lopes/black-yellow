﻿using ShopManagement.UnitTests.TestDataBuilders;
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
            Assert.Equal(sut.Products.Count(), order.Products.Count());
            Assert.Equal(sut.Products.FirstOrDefault().Price, order.Products.FirstOrDefault().Price);
            Assert.Equal(sut.Total, order.Total);
        }
    }
}
