using System;

namespace PubSub.Producer.WebApi.Model
{
    public class ProducerMessage
    {
        public ProducerMessage()
        {
            CreatedAt = DateTime.Now;
        }

        public string Provider { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; }

    }
}
