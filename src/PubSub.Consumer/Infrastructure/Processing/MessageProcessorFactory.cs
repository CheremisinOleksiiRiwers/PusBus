using Confluent.Kafka;
using PubSub.Consumer.Infrastructure.Abstraction;
using PubSub.Consumer.Infrastructure.Interfaces;

namespace PubSub.Consumer.Infrastructure.Processing
{
    public class MessageProcessorFactory : IMessageProcessorFactory
    {
        private ConsumerConfig conf;

        public MessageProcessorFactory(ConsumerConfig conf)
        {
            this.conf = conf;
        }

        public BaseMessageProcessor GetProcessorsChain()
        {
            var unknow = new UnknownMessageProcessor("");

            switch (conf.GroupId.ToUpper())
            {
                case "YOUTUBE":                   
                    return new YoutubeMessageProcessor(conf.GroupId);
                case "FACEBOOK":
                    return new FacebookMessageProcessor(conf.GroupId);
                default:
                    return unknow;
            }
        }
    }
}
