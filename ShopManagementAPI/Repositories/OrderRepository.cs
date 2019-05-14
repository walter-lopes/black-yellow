using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using ShopManagementAPI.DataAccess;
using ShopManagementAPI.Domain;

namespace ShopManagementAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IDbContext DbContext { get; set; }
        private IMongoCollection<Order> Collection { get; set; }

        public OrderRepository(IDbContext context)
        {
            this.DbContext = context;
            this.Collection = context.Context.GetCollection<Order>(typeof(Order).Name);
        }

        public IEnumerable<Order> Get()
        {
            var result = this.Collection.Find(FilterDefinition<Order>.Empty);

            if (result == null)
                return new List<Order>();

            return result.ToList();
        }

        public void Save(Order order)
        {
            this.Collection.InsertOne(order);
        }

        public Order GetById(Guid id)
        {
            var result = this.Collection.Find(x => x.Id == id);
            return result;
        }
    }
}
