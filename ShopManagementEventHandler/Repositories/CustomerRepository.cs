using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using ShopManagementAPI.Domain;
using ShopManagementEventHandler.Context;

namespace ShopManagementEventHandler.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private IMongoCollection<Customer> Collection { get; set; }

        public CustomerRepository(MongoContext context)
        {
            this.Collection = context.Context.GetCollection<Customer>(typeof(Customer).Name);
        }

        public async Task SaveAsync(Customer customer)
        {
            await this.Collection.InsertOneAsync(customer);
        }

        public IEnumerable<Customer> Get()
        {
            var result = this.Collection.Find(FilterDefinition<Customer>.Empty);

            if (result == null)
                return new List<Customer>();

            return result.ToList();
        }
    }
}
