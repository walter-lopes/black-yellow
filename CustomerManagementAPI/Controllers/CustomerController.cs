using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.CustomerManagementAPI.Events;
using BlackYellow.Infrastructure.Messaging;
using CustomerManagementAPI.Commands;
using CustomerManagementAPI.Domain;
using CustomerManagementAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMessagePublisher _messagePublisher;

        public CustomerController(ICustomerRepository customerRepository, IMessagePublisher messagePublisher)
        {
            _customerRepository = customerRepository;
            _messagePublisher = messagePublisher;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterCustomer command)
        {
            try
            {
                Customer customer = new Customer(command.Name, command.Email);
                _customerRepository.Save(customer);

                CustomerRegistered e = new CustomerRegistered(Guid.NewGuid(), customer.Id.ToString(), command.Name, command.Email);
                await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                return Accepted();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_customerRepository.Get());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}