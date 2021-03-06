﻿using BlackYellow.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagementEventHandler.Events
{
    public class ProductRegistered : Event
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public ProductRegistered(Guid messageId, Guid id, string name, string description, double price, int quantity)
            : base(messageId, MessageTypes.ProductRegistered)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Quantity = quantity;
        }
    }
}
