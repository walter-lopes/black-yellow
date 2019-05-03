using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.CustomerManagementAPI.Domain;
using CustomerManagementAPI.DataAccess;
using MongoDB.Driver;

namespace BlackYellow.CustomerManagementAPI.Repositories
{
    public class CartRepository : ICartRepository
    {
        private IMongoCollection<Cart> Collection { get; set; }

        public CartRepository(MongoContext context)
        {
            this.Collection = context.Context.GetCollection<Cart>(typeof(Cart).Name);
        }

        public IEnumerable<Cart> Get()
        {
            var result = this.Collection.Find(FilterDefinition<Cart>.Empty);

            if (result == null)
                return new List<Cart>();

            return result.ToList();
        }

        public async Task Save(Cart cart)
        {
            await this.Collection.InsertOneAsync(cart);
        }
    }
}
