namespace UDPClient;

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;

class UDPClient
{
    List<Socket> clientList;
    private string remoteAddress;
    private string localAddress;
    private int localPort;
    private int remotePort;
    private string? username = null;
    private ConsoleColor userChatColor;

    public UDPClient(string localAddress, int localPort)
    {
        this.localAddress = localAddress;
        this.localPort = localPort;
        this.remotePort = 88;
    }

    public async Task ReceiveMessageAsync()
    {
        byte[] data = new byte[65535];
        using Socket receiver = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        EndPoint remoteSender = new IPEndPoint(IPAddress.Any, 0);
        receiver.Bind(new IPEndPoint(IPAddress.Parse(localAddress), localPort));
        while (true)
        {
            var result = await receiver.ReceiveFromAsync(data, remoteSender);
            System.Text.ASCIIEncoding encode = new System.Text.ASCIIEncoding();
            encode.GetString(data, 0, result.ReceivedBytes);
            Console.WriteLine("Received " + result.ReceivedBytes + " bytes from " +
                              remoteSender.ToString() + ": " +
                              encode.GetString(data, 0, result.ReceivedBytes));
        }
    }

    public async Task SendMessageToGeneralAsync(string message)
    {
        using Socket sender = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        message = $"{username}: {message}";
        System.Text.ASCIIEncoding encode = new System.Text.ASCIIEncoding();
        byte[] inputToBeSent = encode.GetBytes(message);
        EndPoint receiverEP = new IPEndPoint(IPAddress.Parse(localAddress), remotePort);
        await sender.SendToAsync(inputToBeSent, SocketFlags.None, receiverEP);
    }
}
