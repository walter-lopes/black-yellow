using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Domain
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public double Price { get; private set; }

        public Product(Guid id, string name, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }
    }
}
