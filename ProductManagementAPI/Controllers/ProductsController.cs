using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Commands;
using ProductManagementAPI.Models;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IDbContext DbContext { get; set; }
        private IMongoCollection<Product> Collection { get; set; }
        private readonly IMessagePublisher _messagePublisher;

        public ProductsController(IDbContext context)
        {
            this.DbContext = context;
            this.Collection = context.Context.GetCollection<Product>(typeof(Product).Name);
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

                ProductRegistered e = new ProductRegistered(Guid.NewGuid(), product.Id.ToString(), command.Name,
                command.Description, command.OwnerId.ToString());

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