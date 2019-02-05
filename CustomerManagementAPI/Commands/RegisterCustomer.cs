using BlackYellow.Infrastructure.Messaging;
using System;
namespace CustomerManagementAPI.Commands
{
    public class RegisterCustomer 
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
