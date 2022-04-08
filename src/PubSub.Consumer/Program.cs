using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System.IO;
using System.Threading.Tasks;
using PubSub.Consumer.Infrastructure;
using PubSub.Consumer.Infrastructure.Integration;
using PubSub.Consumer.Infrastructure.Interfaces;
using PubSub.Consumer.Infrastructure.Processing;

namespace PubSub.Consumer
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            var consumerType = args[0];

            var host = new HostBuilder()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .ConfigureHostConfiguration(configurationBuilder =>
                    {
                        configurationBuilder.AddJsonFile("appsettings.json", false);
                    }).ConfigureServices((hostContext, services) =>
            {
                var config = hostContext.Configuration.GetSection("KafkaConsumerCongig").Get<ConsumerConfig>();
                config.GroupId = consumerType;
                services.AddSingleton(config);

                services.AddScoped<IMessageConsumer, MessageConsumer>();
                services.AddScoped<IMessageProcessorFactory, MessageProcessorFactory>();
                services.AddHostedService<MessageService>();

            }).UseConsoleLifetime().Build();

            await host.RunAsync();
        }
    }
}
