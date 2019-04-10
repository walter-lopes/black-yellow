using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopManagementAPI.Commands;
using ShopManagementAPI.Domain;
using ShopManagementAPI.Repositories;

namespace ShopManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;

        public ShopController(IOrderItemRepository orderItemRepository, IOrderRepository orderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
        }

        // GET: api/Order
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        [HttpPost]
        [Route("Cart")]
        public void Cart([FromBody] AddOrderItem command)
        {
            OrderItem orderItem = new OrderItem(command.Id, command.Name, command.Price, command.Quantity);

            _orderItemRepository.Save(orderItem);
        }

        // POST: api/Order
        [HttpPost]
        [Route("Order")]
        public void Order([FromBody] CreateOrder command)
        {
            Order order = new Order(command.CustomerId, command.OrderItems);

            _orderRepository.Save(order);
        }
    }
}
