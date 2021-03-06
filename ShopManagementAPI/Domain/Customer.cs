﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Domain
{
    public class Customer
    {
        public Guid Id { get; private set; } = new Guid();

        public string Name { get; private set; }

        public string Email { get; private set; }

        public Customer(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}
