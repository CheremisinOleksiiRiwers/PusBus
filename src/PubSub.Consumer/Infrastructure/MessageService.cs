using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Hosting;

using PubSub.Consumer.Infrastructure.Abstraction;
using PubSub.Consumer.Infrastructure.Interfaces;

namespace PubSub.Consumer.Infrastructure
{
    public class MessageService : IHostedService,IDisposable
    {
        private IMessageConsumer consumer;
        private BaseMessageProcessor processor;

        private CancellationTokenSource stoppingTokenSource;

        public MessageService(IMessageConsumer consumer, IMessageProcessorFactory factory)
        {
            this.consumer = consumer;
            this.processor = factory.GetProcessorsChain();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"-------Start consuming--------");

            stoppingTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            while (!stoppingTokenSource.Token.IsCancellationRequested) {
                Handle(stoppingTokenSource.Token);
            }

            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        public virtual void Handle(CancellationToken cancellationToken)
        {
            try
            {
                string? message = consumer.ReadMessage(cancellationToken);

                if (message == null)
                    return;

                processor.Process(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong!");
            }      
        }

        public void Dispose()
        {
            stoppingTokenSource?.Cancel();
        }
    }
}
