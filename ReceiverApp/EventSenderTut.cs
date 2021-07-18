using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using MassTransit;

namespace ReceiverApp
{
    public class EventSenderTut : IConsumer<Product>
    {
        public async Task Consume(ConsumeContext<Product> context)
        {
            var tt = context.Message;
        }
    }
}
