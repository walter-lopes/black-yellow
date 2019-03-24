using BlackYellow.Infrastructure.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProductManagementAPI.Commands;
using ProductManagementAPI.DataAccess;
using ProductManagementAPI.Events;
using ProductManagementAPI.Models;
using System;
using System.Threading.Tasks;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IDbContext DbContext;
        private readonly IMongoCollection<Product> Collection;
        private readonly IMessagePublisher _messagePublisher;

        public ProductsController(IDbContext context, IMessagePublisher messagePublisher)
        {
            this.DbContext = context;
            this.Collection = context.Context.GetCollection<Product>(typeof(Product).Name);
            this._messagePublisher = messagePublisher;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var products = await this.Collection.FindAsync(FilterDefinition<Product>.Empty);

                if (products is null)
                    return NotFound();

                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterProduct command)
        {
            try
            {
                Product product = new Product()
                {
                    Id = command.Id,
                    Description = command.Description,
                    Name = command.Name,
                    OwnerId = command.OwnerId
                };

                this.Collection.InsertOne(product);

                ProductRegistered e = new ProductRegistered(Guid.NewGuid(), product.Id, command.Name,
                command.Description, command.OwnerId);

                await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                return Accepted();                
            }
            catch (System.Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}