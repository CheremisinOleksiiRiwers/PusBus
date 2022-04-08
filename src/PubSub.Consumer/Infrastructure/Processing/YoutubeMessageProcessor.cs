using System;
using System.Collections.Generic;
using System.Text;
using PubSub.Consumer.Infrastructure.Abstraction;
using PubSub.Consumer.Model;

namespace PubSub.Consumer.Infrastructure.Processing
{
    public class YoutubeMessageProcessor : BaseMessageProcessor
    {
        public YoutubeMessageProcessor(string provider):base(provider){}

        protected override void ProcessMessage(ConsumerMessage message)
        {
            Console.WriteLine($"New video was added to one of your subscription at {message.CreatedAt}. Description: '{message.Value}'");
        }
    }
}
