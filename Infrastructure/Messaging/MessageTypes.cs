using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Infrastructure.Messaging
{
    public enum MessageTypes
    {
        // General
        Unknown,

        // Commands
        RegisterCustomer,
        RegisterProduct,
        CreateOrder,
        AddOrderItem,

        // Events
        CustomerRegistered,
        ProductRegistered,
    }
}
