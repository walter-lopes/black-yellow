using CustomerManagementAPI.DataAccess;
using CustomerManagementAPI.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private  IDbContext DbContext { get; set; }
        private  IMongoCollection<Customer> Collection { get; set; }

        public CustomerRepository(IDbContext context)
        {
            this.DbContext = context;
            this.Collection = context.Context.GetCollection<Customer>(typeof(Customer).Name);
        }

        public void Save(Customer customer)
        {        
            this.Collection.InsertOne(customer);         
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
