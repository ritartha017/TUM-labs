using System.Diagnostics;
using System.Text;

namespace MultiConBroker;

class Program
{
    static Broker broker;

    static void Main(string[] args)
    {
        Console.WriteLine("[BROKER] started listenning..");
        broker = new Broker(8);
        broker.SocketAccepted += new EventHandler<PublisherAcceptedEventHandler>(Broker_SocketAccepted);
        broker.Start();

        Process.GetCurrentProcess().WaitForExit();
    }

    static void Broker_SocketAccepted(object publisher, PublisherAcceptedEventHandler e)
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