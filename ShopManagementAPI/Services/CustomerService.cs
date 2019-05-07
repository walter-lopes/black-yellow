using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Services
{
    public interface ICustomerService
    {
        [AllowAnyStatusCode]
        [Get("carts/{id}")]
        Task<CartDto> GetCartAsync([Path] Guid id);
    }

    public class CartDto
    {
        public Guid Id { get; set; }
        public IEnumerable<CartItemDto> Items { get; set; }
    }

    public class CartItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
