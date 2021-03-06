﻿using ShopManagementAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Get();

        Order GetById(Guid id);

        void Save(Order order);
    }
}
