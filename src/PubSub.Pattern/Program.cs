using PubSub.Pattern.Infrastructure;
using System.Threading.Tasks;

namespace PubSub.Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher youtube = new Publisher("Youtube.Com", 2000);
            Publisher facebook = new Publisher("Facebook.com", 1000);

            Subscriber sub1 = new Subscriber("Oleksii");
            Subscriber sub2 = new Subscriber("Alex");
            Subscriber sub3 = new Subscriber("Yehor");

            sub1.Subscribe(facebook); 
            sub3.Subscribe(facebook);

            sub1.Subscribe(youtube);
            sub2.Subscribe(youtube);

            try
            {
                Task task1 = Task.Factory.StartNew(() => youtube.Publish("There is new video"));
                Task task2 = Task.Factory.StartNew(() => facebook.Publish("There is new article"));
                Task.WaitAll(task1, task2);
            }
            finally {
                sub1.Unsubscribe(facebook);
                sub3.Unsubscribe(facebook);

                sub1.Unsubscribe(youtube);
                sub2.Unsubscribe(youtube);
            }
        }
    }
}
