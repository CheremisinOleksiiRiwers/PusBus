using System;

namespace PubSub.Pattern.Infrastructure
{
    public class NotificationEvent
    {
        public string Message { get; private set; }

        public DateTime Date { get; private set; }

        public NotificationEvent(string message, DateTime date)
        {
            Message = message;
            Date = date;
        }
    }
}
