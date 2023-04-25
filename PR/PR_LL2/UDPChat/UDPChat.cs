namespace UDPChatNamespace;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPChat
{
    private const int MAX_LEN = 1024;
    private string multicastIP;
    private int multicastPort;
    private string? username;
    bool done = false;
    int ttl = 1; // time to live (1 hop)
    private ConsoleColor userChatColor;

    public UDPChat(string multicastIP, int multicastPort = 8888)
    {
        this.multicastIP = multicastIP;
        this.multicastPort = multicastPort;
        userChatColor = RandomColorHelper.GetRandomConsoleColor();
        Console.Write("Enter your name: ");
        username = Console.ReadLine();
    }

    public async Task SendMessageToGeneralAsync(string message)
    {
        using Socket sender = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        sender.SetSocketOption(SocketOptionLevel.IP,
                               SocketOptionName.AddMembership,
                               new MulticastOption(IPAddress.Parse(multicastIP)));
        sender.SetSocketOption(SocketOptionLevel.IP,
                               SocketOptionName.MulticastTimeToLive,
                               ttl);
        message = $"{username}: {message}";
        byte[] data = Encoding.UTF8.GetBytes(message);
        EndPoint receiverEP = new IPEndPoint(IPAddress.Parse(multicastIP), multicastPort);
        await sender.SendToAsync(data, receiverEP);
    }

    public async Task SendMessageToIpAsync(string concreteIP, string message)
    {
        using Socket sender = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        sender.SetSocketOption(SocketOptionLevel.IP,
                               SocketOptionName.AddMembership,
                               new MulticastOption(IPAddress.Parse(multicastIP)));
        sender.SetSocketOption(SocketOptionLevel.IP,
                               SocketOptionName.MulticastTimeToLive,
                               ttl);
        message = $"{username}: {message}";
        byte[] data = Encoding.UTF8.GetBytes(message);
        EndPoint receiverEP = new IPEndPoint(IPAddress.Parse(concreteIP), multicastPort);
        await sender.SendToAsync(data, receiverEP);
    }

    public async Task ReceiveMessageAsync()
    {
        byte[] data = new byte[MAX_LEN];
        using Socket receiver = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint remoteSender = new(IPAddress.Any, multicastPort);
        receiver.Bind(remoteSender);
        receiver.SetSocketOption(SocketOptionLevel.IP,
                                 SocketOptionName.AddMembership,
                                 new MulticastOption(IPAddress.Parse(multicastIP)));
        while (!done)
        {
            var result = await receiver.ReceiveFromAsync(data, remoteSender);
            var message = Encoding.UTF8.GetString(data, 0, result.ReceivedBytes);
            var splitted = message.Split(":");
            string userName = splitted[0];
            string text = splitted[1];
            Console.ForegroundColor = userChatColor;
            Console.Write($"{DateTime.Now:MM/dd/yyyy h:mm tt} {userName}>");
            Console.ResetColor();
            Console.WriteLine(text);
        }
        // Drop membership
        receiver.SetSocketOption(SocketOptionLevel.IP,
                                 SocketOptionName.DropMembership,
                                 new MulticastOption(IPAddress.Parse(multicastIP)));
    }
}
