using Confluent.Kafka;
using Newtonsoft.Json;
using PubSub.Producer.WebApi.Infrastructure.Interfaces;
using PubSub.Producer.WebApi.Model;
using System;
using System.Threading.Tasks;

namespace PubSub.Producer.WebApi.Infrastructure
{
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IKafkaProducer producer;

        public MessagePublisher(IKafkaProducer producer)
        {
            this.producer = producer;
        }

        public async Task<bool> PublishMessageAsync(ProducerMessage message)
        {
            try
            {
                var res = await producer.ProduceAsync("testtopic", message);
                return res.Status == PersistenceStatus.Persisted;
            }
            catch (ProduceException<Null, string> exception) {
                return false;
            }
        }
    }
}
