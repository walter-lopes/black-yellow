using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.CustomerManagementAPI.Commands;
using BlackYellow.CustomerManagementAPI.Domain;
using BlackYellow.CustomerManagementAPI.Repositories;
using BlackYellow.Infrastructure.Messaging;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackYellow.CustomerManagementAPI.Controllers
{

    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMessagePublisher _messagePublisher;


        public CartController(ICartRepository cartRepository, IMessagePublisher messagePublisher)
        {
            _cartRepository = cartRepository;
            _messagePublisher = messagePublisher;
        }


        // GET: /<controller>/
        public IActionResult Add(AddProductToCart addProductToCart)
        {
            Cart cart = new Cart(addProductToCart.CustomerId);

            cart.AddProduct(addProductToCart.Product, addProductToCart.Qtd);

            _cartRepository.Save(cart);

            return Ok();
        }

        public IActionResult Get(Guid customerId)
        {
            return Ok(_cartRepository.Get());
        }
    }
}
