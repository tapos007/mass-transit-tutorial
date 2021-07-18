using System;
using System.Threading.Tasks;
using Common;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace SenderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IBus _bus;
        private readonly IRequestClient<OrderRequest> _client;

        public ValuesController(IBus bus, IRequestClient<OrderRequest> client)
        {
            _bus = bus;
            _client = client;
        }


        //publish testing work

        [HttpPost]
        public async Task<IActionResult> Test1()
        {

            await _bus.Publish(new ValueEnter()
            {
                Name = "sumon",
                Email = "sumon@gmail.com"
            });
            return Ok("good boy");
        }


        //sender testing work

        [HttpPost("test2")]
        public async Task<IActionResult> Test2()
        {

            var product = new Product()
            {
                Name = "distance  hair",
                Price = 200
            };
            var url = new Uri("rabbitmq://location/send-tutorial");

            var endPoint = await _bus.GetSendEndpoint(url);
            await endPoint.Send(product);
            
            return Ok("good boy");
        }

        //request testing work

        [HttpPost("test3")]
        public async Task<IActionResult> Test3()
        {
            var requestData = new OrderRequest()
            {
                Id = "sonu"
            };
            var request = _client.Create(requestData);

            var response = await request.GetResponse<Product>();

           

            return Ok(response);
        }

    }
}
