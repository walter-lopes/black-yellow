using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Domain
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public string Email { get; private set; }

        public Customer(Guid id, string name, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }
    }
}
