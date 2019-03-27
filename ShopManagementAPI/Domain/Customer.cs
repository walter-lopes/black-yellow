using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
