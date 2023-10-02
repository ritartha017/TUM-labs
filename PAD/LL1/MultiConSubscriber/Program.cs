using System.Text;
using MultiConSubscriber.EventHandlers;
using MultiConSubscriber.Models;
using Common.Data;

namespace MultiConSubscriber;

class Program
{
    static Subscriber subscriber;

    static void Main()
    {
        Console.WriteLine("[SUBSCRIBER]");
        subscriber = new Subscriber("coded2");

        subscriber.Connected += new EventHandler<ConnectedHandler>(Broker_Connected);

        var connected = subscriber.StartConnect(CommonConstants.BROKER_IP, CommonConstants.BROKER_PORT);
        if (!connected) return;
        Thread.Sleep(10);
        subscriber.Subscribe();

        Console.Read();
    }

    private static void Broker_Connected(object? sender, ConnectedHandler e)
    {
        Broker b = new(e.Socket);
        b.Received += new EventHandler<ReceivedHandler>(Received);
    }

    private static void Received(object? sender, ReceivedHandler e)
    {
        Console.WriteLine(Encoding.UTF8.GetString(e.data, 0, e.data.Length));
    }
}
