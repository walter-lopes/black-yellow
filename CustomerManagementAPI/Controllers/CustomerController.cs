using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementAPI.Commands;
using CustomerManagementAPI.Models;
using CustomerManagementAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
    }
        [HttpPost]
        public IActionResult Register([FromBody] RegisterCustomer command)
        {
            try
            {
                Customer customer = new Customer() { Email = command.Email, Name = command.Name };
                _customerRepository.Save(customer);
                return  Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}