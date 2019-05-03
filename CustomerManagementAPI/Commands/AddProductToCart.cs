using BlackYellow.CustomerManagementAPI.Domain;
using System;

namespace BlackYellow.CustomerManagementAPI.Commands
{
    public class AddProductToCart 
    {
        public Guid CustomerId { get; set; }

        public Product Product { get; set; }

        public int Qtd { get; set; }
    }
}