using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using MassTransit;

namespace ReceiverApp
{
    public class EventRequestTut : IConsumer<OrderRequest>
    {
        public async Task Consume(ConsumeContext<OrderRequest> context)
        {
           var product = new Product()
           {
               Name = context.Message.Id,
               Price = 1000
           };

           await context.RespondAsync<Product>(product);

        }
    }
}
