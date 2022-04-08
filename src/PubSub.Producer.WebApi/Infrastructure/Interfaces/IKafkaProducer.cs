using Confluent.Kafka;
using PubSub.Producer.WebApi.Model;
using System.Threading.Tasks;

namespace PubSub.Producer.WebApi.Infrastructure.Interfaces
{
    public interface IKafkaProducer
    {
        Task<DeliveryResult<Null, string>> ProduceAsync(string topic, ProducerMessage message);
    }
}
