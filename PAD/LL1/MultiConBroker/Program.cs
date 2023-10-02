using System.Diagnostics;
using System.Text;
using Common.Data;

namespace MultiConBroker;

class Program
{
    static Broker broker;

    static void Main()
    {
        Console.WriteLine("[BROKER] started listenning..");
        broker = new Broker(CommonConstants.BROKER_PORT);
        broker.SocketAccepted += new EventHandler<AcceptedHandler>(Broker_SocketAccepted);
        broker.Start();

        // var worker = new MessagesSender();
        // Task.Factory.StartNew(worker.SendMessages, TaskCreationOptions.LongRunning);

        Process.GetCurrentProcess().WaitForExit();
    }

    static void Broker_SocketAccepted(object publisher, AcceptedHandler e)
    {
        Console.WriteLine("New Connection: {0} DateTime: {1}", e.Accepted.RemoteEndPoint, DateTime.Now);
        Publisher socket = new(e.Accepted);
        socket.Received += new EventHandler<ReceivedHandler>(PublisherReceived);
        socket.Disconnected += new EventHandler<DisconnectedHandler>(PublisherDisconnected);
        socket.StartReceive();
    }

    private static void PublisherDisconnected(object? publisher, DisconnectedHandler e)
    {
        Console.WriteLine($"Disconnected: {e.Publisher.EndPoint}");
    }

    private static void PublisherReceived(object? publisher, ReceivedHandler e)
    {
        Console.WriteLine($"{e.Publisher.EndPoint}: { Encoding.UTF8.GetString(e.data, 0, e.data.Length)}");
    }
}