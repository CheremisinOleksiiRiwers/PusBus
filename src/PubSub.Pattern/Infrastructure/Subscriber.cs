using System;

namespace PubSub.Pattern.Infrastructure
{
    public class Subscriber
    {
        private readonly string name;

        public Subscriber(string name)
        {
            this.name = name;
        }

        public void Subscribe(Publisher publisher) {
            publisher.OnPublish += OnNotificationReceived;
        }

        public void Unsubscribe(Publisher publisher)
        {
            publisher.OnPublish -= OnNotificationReceived;
        }

        public void OnNotificationReceived(string publisherName, NotificationEvent notification) {

            Console.WriteLine($"Hello {name}, you have got message: '{notification.Message}' from {publisherName} at {notification.Date}");
        
        }
    }
}
