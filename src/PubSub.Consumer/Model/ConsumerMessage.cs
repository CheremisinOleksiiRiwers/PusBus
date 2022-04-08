using System;

namespace PubSub.Consumer.Model
{
    public class ConsumerMessage
    {
        public string Provider { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
