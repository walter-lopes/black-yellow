using CustomerManagment.UnitTests.TestDataBuilders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CustomerManagment.UnitTests.DomainTests
{
    public class CustomerTest
    {
        [Fact]
        public void Customer_Should_Has_Created()
        {
            CustomerBuilder sut = new CustomerBuilder();
            var order = sut.Build();

            Assert.Equal(sut.Email, order.Email);
            Assert.Equal(sut.Name, order.Name);
        }
    }
}
