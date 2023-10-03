using System.Diagnostics;
using System.Text;
using Common.Data;
using MultiConBroker.Repos;
using Newtonsoft.Json;

namespace MultiConBroker;

class Program
{
    static Broker broker;

    static void Main(string[] args)
    {
        Console.WriteLine("[BROKER] started listenning..");
        broker = new Broker(CommonConstants.BROKER_PORT);
        broker.SocketAccepted += new EventHandler<AcceptedHandler>(Broker_SocketAccepted);
        broker.Start();

        var worker = new MessagesSender();
        //Task.Factory.StartNew(worker.SendMessages, TaskCreationOptions.LongRunning);
        Task.Run(worker.SendMessages);
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
        var payloadString = Encoding.UTF8.GetString(e.data, 0, e.data.Length);
        Console.WriteLine($"{e.Publisher.EndPoint}: { payloadString }");

        if (payloadString.StartsWith("subscribe#"))
        {
            var topic = payloadString.Split("subscribe#").LastOrDefault();
            SubscribersRepository.Add(new Subscriber() { Topic = topic, Address = e.Publisher.EndPoint.Address.ToString(), Socket = e.Publisher.publisherSocket });

        }
        else if (JsonHelper.IsValidJson(payloadString))
        {
            Payload? payload = JsonConvert.DeserializeObject<Payload>(payloadString);
            PayloadQueue.Add(payload);
        }
    }
}