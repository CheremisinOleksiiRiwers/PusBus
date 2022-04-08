using Confluent.Kafka;
using Moq;
using PubSub.Producer.WebApi.Infrastructure;
using PubSub.Producer.WebApi.Infrastructure.Interfaces;
using PubSub.Producer.WebApi.Model;
using System.Threading.Tasks;
using Xunit;

namespace PubSub.Tests
{
    public class ProducerTests
    {
        [Fact]
        public async Task PublishMessage_SuccessfulResponse_RetunsTrue()
        {
            var producerMock = new Mock<IKafkaProducer>();
            var deliveryResult = new DeliveryResult<Null, string>();
            deliveryResult.Status = PersistenceStatus.Persisted;
            producerMock.Setup(m => m.ProduceAsync(It.IsAny<string>(), It.IsAny<ProducerMessage>())).ReturnsAsync(deliveryResult);

            var messagePublisher = new MessagePublisher(producerMock.Object);

            var actual = await messagePublisher.PublishMessageAsync( new ProducerMessage { Provider="pr", Value = "val"});
            Assert.True(actual);
        }

        [Fact]
        public async Task PublishMessage_ProduceException_RetunsFail()
        {

            var producerMock = new Mock<IKafkaProducer>(); 
            var error = new Error(ErrorCode.Local_BadMsg, "Exception");
            var exception = new ProduceException<Null, string>(error, null);
            producerMock.Setup(m => m.ProduceAsync(It.IsAny<string>(), It.IsAny<ProducerMessage>())).ThrowsAsync(exception);

           
            var producerProcessor = new MessagePublisher(producerMock.Object);


            var actual = await producerProcessor.PublishMessageAsync(new ProducerMessage { Provider = "pr", Value = "val" });
            Assert.False(actual);
        }
    }
}
