using Newtonsoft.Json;
using PubSub.Consumer.Model;

namespace PubSub.Consumer.Infrastructure.Abstraction
{
    public abstract class BaseMessageProcessor
    {
        private readonly string provider;

        public BaseMessageProcessor(){}

        protected BaseMessageProcessor(string provider) {
            this.provider = provider;
        }

        public BaseMessageProcessor Next { get; set; }
       
        public virtual void Process(string consumedMessage) {

            var message = JsonConvert.DeserializeObject<ConsumerMessage>(consumedMessage);

            if (CanHandle(message.Provider))
                ProcessMessage(message);

            Next?.Process(consumedMessage);
        }

        public virtual bool CanHandle(string provider) {
            return this.provider.ToUpper() == provider.ToUpper();
        }

        protected abstract void ProcessMessage(ConsumerMessage message);

    }
}
