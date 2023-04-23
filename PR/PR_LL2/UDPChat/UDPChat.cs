namespace UDPChat;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPChat
{
    private string multicastIP;
    private int multicastPort;
    private string? username = null;
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
        message = $"{username}: {message}";
        byte[] data = Encoding.UTF8.GetBytes(message);
        EndPoint receiverEP = new IPEndPoint(IPAddress.Parse(multicastIP), multicastPort);
        await sender.SendToAsync(data, receiverEP);
    }

    public async Task SendMessageToIpAsync(string concreteIP)
    {
        using Socket sender = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        Console.WriteLine("Type message and press Enter");
        while (true)
        {
            var message = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(message)) break;
            message = $"{username}: {message}";
            byte[] data = Encoding.UTF8.GetBytes(message);
            await sender.SendToAsync(data, new IPEndPoint(IPAddress.Parse(concreteIP), multicastPort));
        }
    }

    public async Task ReceiveMessageAsync()
    {
        byte[] data = new byte[65535];
        using Socket receiver = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        EndPoint remoteSender = new IPEndPoint(IPAddress.Any, 0);
        receiver.Bind(new IPEndPoint(IPAddress.Parse(multicastIP), multicastPort));
        receiver.SetSocketOption(SocketOptionLevel.IP,
                                SocketOptionName.AddMembership,
                                new MulticastOption(IPAddress.Parse(multicastIP)));
        while (true)
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
    }
}
