using CustomerManagementAPI.DataAccess;
using CustomerManagementAPI.Models;
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
            if (customer.Id == null || customer.Id.Equals(""))
            {
                this.Collection.InsertOne(customer);
            }
            else
            {
                this.Collection.FindOneAndReplace(obj => obj.Id.Equals(customer.Id), customer);
            }
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
