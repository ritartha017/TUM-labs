using System.Diagnostics;
using System.Text;
using Common.Data;
using MultiConBroker.Repos;
using Newtonsoft.Json;

namespace MultiConBroker;

class Program
{
    static Broker broker;

    static void Main()
    {
        Console.WriteLine("[Broker started listenning..]");
        broker = new Broker(CommonConstants.BROKER_PORT);
        broker.SocketAccepted += new EventHandler<AcceptedHandler>(Broker_SocketAccepted);

        broker.Start();

        var worker = new MessagesSender();
        Task.Factory.StartNew(worker.SendMessages, TaskCreationOptions.LongRunning);

        Process.GetCurrentProcess().WaitForExit();
    }

    static void Broker_SocketAccepted(object publisher, AcceptedHandler e)
    {
        Console.WriteLine("New Connection: {0} DateTime: {1}", e.AcceptedSocket.RemoteEndPoint, DateTime.Now);
        Client socket = new(e.AcceptedSocket);
        socket.Received += new EventHandler<ReceivedHandler>(Broker_ClientReceived);
        socket.Disconnected += new EventHandler<DisconnectedHandler>(Broker_ClientDisconnected);
        socket.StartReceive();
    }

    private static void Broker_ClientReceived(object? publisher, ReceivedHandler e)
    {
        var payloadString = Encoding.UTF8.GetString(e.Data, 0, e.Data.Length);
        Console.WriteLine($"{e.ReceivedSocket.RemoteEndPoint}: { payloadString }");

        if (payloadString.StartsWith(CommonConstants.SubscribePrefix))
        {
            var topic = payloadString.Split(CommonConstants.SubscribePrefix).LastOrDefault();
            SubscribersRepository.Add(new Subscriber() { Topic = topic, Address = e.ReceivedSocket.RemoteEndPoint.ToString(), Socket = e.ReceivedSocket });
        }
        else if (JsonHelper.IsValidJson(payloadString))
        {
            Payload? payload = JsonConvert.DeserializeObject<Payload>(payloadString);
            PayloadQueue.Add(payload);
        }
    }

    private static void Broker_ClientDisconnected(object? publisher, DisconnectedHandler e)
    {
        Console.WriteLine($"Disconnected: {e.DisconnectedSocket.RemoteEndPoint}");
    }
}