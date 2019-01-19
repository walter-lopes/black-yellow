using System;
namespace CustomerManagementAPI.Commands
{
    public class RegisterCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
