using Confluent.Kafka;
using System;
using System.Threading;
using PubSub.Consumer.Infrastructure.Interfaces;

namespace PubSub.Consumer.Infrastructure.Integration
{
    public class MessageConsumer:IMessageConsumer
    {
        private IConsumer<Ignore, String> consumer;

        public MessageConsumer(ConsumerConfig config)
        {
            consumer = new ConsumerBuilder<Ignore, string>(config).Build();

            consumer.Subscribe("testtopic");            
        }

        public string? ReadMessage(CancellationToken cancellationToken)
        {
            var message = consumer.Consume(cancellationToken).Message;

            return message?.Value;
        }
    }
}
