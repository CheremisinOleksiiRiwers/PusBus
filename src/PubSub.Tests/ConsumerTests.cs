using System.Threading;
using System.Threading.Tasks;

using Moq;
using Xunit;

using PubSub.Consumer.Infrastructure;
using PubSub.Consumer.Infrastructure.Abstraction;
using PubSub.Consumer.Infrastructure.Interfaces;
using PubSub.Consumer.Infrastructure.Processing;


namespace PubSub.Tests
{
    public class ConsumerTests
    {
        [Fact]
        public async Task TryGetMessage_ValidMessage_VerifieHandle()
        {
            var consumerMock = new Mock<IMessageConsumer>();

            var processorFactoryMock = new Mock<IMessageProcessorFactory>();

            var serviceMock = new Mock<MessageService>(consumerMock.Object, processorFactoryMock.Object);

            serviceMock.Setup(m => m.Handle(It.IsAny<CancellationToken>())).Callback(() => serviceMock.Object.Dispose()).Verifiable();

            await serviceMock.Object.StartAsync(new CancellationToken());

            serviceMock.Verify(m => m.Handle(It.IsAny<CancellationToken>()), Times.Once);
        }


        [Fact]
        public async Task TryGetMessage_ValidMessage_VerifieProcessor()
        {
            var consumerMock = new Mock<IMessageConsumer>();

            consumerMock.Setup(m => m.ReadMessage(It.IsAny<CancellationToken>())).Returns("OK");

            var processorFactoryMock = new Mock<IMessageProcessorFactory>();

            var processorMock = new Mock<BaseMessageProcessor>();

            processorFactoryMock.Setup(m => m.GetProcessorsChain()).Returns(processorMock.Object).Verifiable();

            var service = new MessageService(consumerMock.Object, processorFactoryMock.Object);

            processorMock.Setup(m => m.Process(It.IsAny<string>())).Callback(() => service.Dispose()).Verifiable();

            await service.StartAsync(new CancellationToken());

            processorMock.Verify(m => m.Process(It.IsAny<string>()), Times.Once);
        }
    }
}
