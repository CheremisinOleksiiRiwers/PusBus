using System;
using PubSub.Consumer.Infrastructure.Abstraction;
using PubSub.Consumer.Model;

namespace PubSub.Consumer.Infrastructure.Processing
{
    public class FacebookMessageProcessor : BaseMessageProcessor
    {
        public FacebookMessageProcessor(string provider) : base(provider) { }

        protected override void ProcessMessage(ConsumerMessage message)
        {
            Console.WriteLine($"New post was addet to facebook at {message.CreatedAt}. Description: '{message.Value}'");
        }
    }
}
