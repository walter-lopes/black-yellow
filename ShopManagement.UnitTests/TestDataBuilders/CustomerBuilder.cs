using ShopManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.UnitTests.TestDataBuilders
{
    public class CustomerBuilder
    {
        public Guid Id { get; private set; }
        public string Name { get; private  set; }
        public string Email { get; private set; }

        public CustomerBuilder()
        {
            SetDefaults();
        }

        public Customer Build()
        {
            return new Customer(this.Name, this.Email);
        }

        private void SetDefaults()
        {
            this.Name = "Walter Vinicius";
            this.Email = "walter.vlopes@gmail.com";
        }
    }
}
