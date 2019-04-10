using ShopManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Repositories
{
    public interface IOrderItemRepository
    {
        IEnumerable<OrderItem> Get();

        void Save(OrderItem order);
    }
}
