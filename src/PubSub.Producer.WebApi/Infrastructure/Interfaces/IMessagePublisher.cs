using PubSub.Producer.WebApi.Model;
using System.Threading.Tasks;

namespace PubSub.Producer.WebApi.Infrastructure.Interfaces
{
    public interface IMessagePublisher
    {
        Task<bool> PublishMessageAsync(ProducerMessage message);
    }
}
