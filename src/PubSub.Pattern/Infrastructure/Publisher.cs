using System;
using System.Threading;

namespace PubSub.Pattern.Infrastructure
{

    public delegate void NotifyDelegate(string identifier, NotificationEvent ev);

    public class Publisher
    {
        private readonly string name;
        private readonly int interval;

        public Publisher(string name, int interval)
        {
            this.name = name;
            this.interval = interval; 
        }        

        public event NotifyDelegate OnPublish;

        public void Publish(string  message) {

            while (true) {

                Thread.Sleep(interval);

                NotifyDelegate notify = OnPublish;

                if (notify != null)
                    notify(name, new NotificationEvent(message, DateTime.Now));

                Thread.Yield();            
            }
        }
    }
}

