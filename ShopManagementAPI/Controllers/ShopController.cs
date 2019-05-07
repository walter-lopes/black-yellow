using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagementAPI.Commands;
using ShopManagementAPI.Domain;
using ShopManagementAPI.Repositories;
using ShopManagementAPI.Services;

namespace ShopManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerService _customerService;

        public ShopController(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository, ICustomerService customerService)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _customerService = customerService;
        }

        [HttpPost]
        [Route("Order")]
        public async Task Order([FromBody] CreateOrder command)
        {

            var cart = await _customerService.GetCartAsync(command.CustomerId);

            var items = cart.Items.Select(i => new OrderItem(i.ProductId,
               i.ProductName, i.UnitPrice, i.Quantity)).ToList();

            Order order = new Order(command.CustomerId, items);

            _orderRepository.Save(order);
        }
    }
}
