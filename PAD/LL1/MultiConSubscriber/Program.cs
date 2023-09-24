using System.Diagnostics;
using System.Text;

namespace MultiConSubscriber;

class Program
{
    static Subscriber subscriber;

    static void Main(string[] args)
    {
        Console.Write("Enter topic: ");
        var topic = Console.ReadLine();
        subscriber = new Subscriber(topic);
        subscriber.Connected += new EventHandler<SubscriberConnectedEventHandler>(Subscriber_Connected);
        subscriber.Start();

        Process.GetCurrentProcess().WaitForExit();
    }

    static void Subscriber_Connected(object publisher, SubscriberConnectedEventHandler e)
    {
        Console.WriteLine("New Connection: {0}\n{1}\n===========", e.Accepted.RemoteEndPoint, DateTime.Now);
        Publisher s = new(e.Accepted);
        s.Received += new EventHandler<PublisherReceivedHandler>(PublisherReceived);
        s.Disconnected += new EventHandler<PublisherDisconnectedHandler>(PublisherDisconnected);
    }

    private static void PublisherDisconnected(object? publisher, PublisherDisconnectedHandler e)
    {
        Console.WriteLine($"Disconnected: {e.Publisher.ID}");
    }

    private static void PublisherReceived(object? publisher, PublisherReceivedHandler e)
    {
        Console.WriteLine(Encoding.UTF8.GetString(e.data, 0, e.data.Length));
    }
}
