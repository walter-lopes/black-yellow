﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagementAPI.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public double Price { get; set; }
    }
}
