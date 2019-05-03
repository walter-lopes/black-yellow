using BlackYellow.Infrastructure.Messaging;
using Newtonsoft.Json.Linq;
using ShopManagementAPI.Domain;
using ShopManagementEventHandler.Events;
using ShopManagementEventHandler.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementEventHandler
{
    public class EventHandler : IMessageHandlerCallback
    {
        private readonly IMessageHandler _messageHandler;
        private readonly ICustomerRepository _customerRepository;

        public EventHandler(IMessageHandler messageHandler, ICustomerRepository customerRepository)
        {
            _messageHandler = messageHandler;
            _customerRepository = customerRepository;
        }

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }

        public async Task<bool> HandleMessageAsync(MessageTypes messageType, string message)
        {
            JObject messageObject = MessageSerializer.Deserialize(message);
            
            return await HandleAsync(messageObject.ToObject<CustomerRegistered>());
          
        }
        
        private async Task<bool> HandleAsync(CustomerRegistered e)
        {
            var customer = new Customer(e.Name, e.Email);
            await _customerRepository.SaveAsync(customer);
            return true;
        }

       
    }
}
