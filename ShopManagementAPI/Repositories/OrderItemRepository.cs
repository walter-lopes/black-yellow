using System;
using System.Collections.Generic;
using MongoDB.Driver;
using ShopManagementAPI.DataAccess;
using ShopManagementAPI.Domain;

namespace ShopManagementAPI.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private IDbContext DbContext { get; set; }
        private IMongoCollection<OrderItem> Collection { get; set; }

        public OrderItemRepository(IDbContext context)
        {
            this.DbContext = context;
            this.Collection = context.Context.GetCollection<OrderItem>(typeof(OrderItem).Name);
        }

        public void Save(OrderItem order)
        {
            this.Collection.InsertOne(order);
        }

        IEnumerable<OrderItem> IOrderItemRepository.Get()
        {
            var result = this.Collection.Find(FilterDefinition<OrderItem>.Empty);

            if (result == null)
                return new List<OrderItem>();

            return result.ToList();
        }
    }
}
