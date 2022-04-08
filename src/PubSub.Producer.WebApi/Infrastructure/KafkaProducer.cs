using Confluent.Kafka;
using Newtonsoft.Json;
using PubSub.Producer.WebApi.Infrastructure.Interfaces;
using PubSub.Producer.WebApi.Model;
using System;
using System.Threading.Tasks;

namespace PubSub.Producer.WebApi.Infrastructure
{
    public class KafkaProducer : IDisposable, IKafkaProducer
    {
        private readonly IProducer<Null, string> producer;
 
        public KafkaProducer(ProducerConfig config)
        {
            producer = new ProducerBuilder<Null, string>(config).Build();
        }

        public async Task<DeliveryResult<Null, string>> ProduceAsync(string topic, ProducerMessage message)
        {
           return  await producer.ProduceAsync(topic, new Message<Null, string> { Value = JsonConvert.SerializeObject(message) });
        }

        public void Dispose()
        {
            producer.Flush();
            producer.Dispose();
        }
    }
}
