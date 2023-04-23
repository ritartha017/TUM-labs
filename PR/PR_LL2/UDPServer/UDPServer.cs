namespace UDPServerNamespace;

using System.Net;
using System.Net.Sockets;
using System.Text;

class UDPServer
{
    List<Socket> clientList;
    private string localAddress;
    private string localPort;
    private int mcPort; // port to receive on
    IPAddress mcIP;    // multicast group to join
    IPAddress localIP; // multicast group to join
    private string? username = null;
    int MAX_LEN = 1024; // max receive buffer size

    string ip = "127.0.0.1";
    string port = "88";

    public UDPServer()
    {
        _ = IPAddress.TryParse(localAddress, out mcIP);
        _ = int.TryParse(localPort, out mcPort);
    }

    public async Task ReceiveMessageAsync()
    {
        byte[] recData = new byte[MAX_LEN];
        using Socket receiver = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint ipEp = new(IPAddress.Any, mcPort);
        receiver.Bind(ipEp);
        EndPoint tempReceivePoint = new IPEndPoint(IPAddress.Any, 0);
        while (true)
        {
            var result = await receiver.ReceiveFromAsync(recData, tempReceivePoint);
            var receivedBytes = result.ReceivedBytes;
            ASCIIEncoding encode = new();
            encode.GetString(recData, 0, receivedBytes);

            Console.WriteLine("Received " + receivedBytes + " bytes from " +
                              tempReceivePoint.ToString() + ": " +
                              encode.GetString(recData, 0, receivedBytes));
        }
    }
}
