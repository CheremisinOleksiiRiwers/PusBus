using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PubSub.Producer.WebApi.Infrastructure.Interfaces;
using PubSub.Producer.WebApi.Model;
using System.Threading.Tasks;

namespace PubSub.Producer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> logger;
        private readonly IMessagePublisher publisher;
     
        public MessagesController(IMessagePublisher publisher,ILogger<MessagesController> logger)
        {
            this.logger = logger;
            this.publisher = publisher;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ProducerMessage message)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await publisher.PublishMessageAsync(message);

            if (result)
                return Ok();

            return BadRequest();

         }
    }
}
