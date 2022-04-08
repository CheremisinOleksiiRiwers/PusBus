using System;
using PubSub.Consumer.Infrastructure.Abstraction;
using PubSub.Consumer.Model;

namespace PubSub.Consumer.Infrastructure.Processing
{
    public class UnknownMessageProcessor : BaseMessageProcessor
    {
        public UnknownMessageProcessor(string provider ):base(provider) {}

        public override bool CanHandle(string provider)
        {
            return true;
        }

        protected override void ProcessMessage(ConsumerMessage message)
        {
            Console.WriteLine($"Unknow provider added message at  {message.CreatedAt}. Description: '{message.Value}'");
        }
    }
}
