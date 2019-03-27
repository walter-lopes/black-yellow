using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Domain
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Customer Customer { get; private set; }

        public IEnumerable<Product> Products { get; private set; }

        public double Total
        {
            get
            {
                return this.Products.Sum(p => p.Price);
            }
        }

        public Order(Customer customer, IEnumerable<Product> products)
        {
            this.Customer = customer;
            this.Products = products;
        }
    }
}
