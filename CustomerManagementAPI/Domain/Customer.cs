﻿using System;

namespace CustomerManagementAPI.Domain
{
    public class Customer
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; }

        public string Email { get; private set; }

        public Customer(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }
}
