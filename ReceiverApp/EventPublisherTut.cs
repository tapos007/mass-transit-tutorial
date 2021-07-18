using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using MassTransit;

namespace ReceiverApp
{
    public class EventPublisherTut : IConsumer<ValueEnter>
    {
        public async Task Consume(ConsumeContext<ValueEnter> context)
        {
            var mm = context.Message;
        }
    }
}
