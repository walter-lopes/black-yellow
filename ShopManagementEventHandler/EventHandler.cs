using BlackYellow.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementEventHandler
{
    public class EventHandler : IMessageHandlerCallback
    {
        private readonly IMessageHandler _messageHandler;

        public EventHandler(IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }

        public Task<bool> HandleMessageAsync(MessageTypes messageType, string message)
        {
            throw new NotImplementedException();
        }
    }
}
