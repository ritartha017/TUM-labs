using System.Net;
using System.Net.Sockets;

namespace MultiConServer;

class Listener
{
    Socket socket;
    public bool Listening { get; private set; }
    public int Port { get; private set; }
    public string Host { get; private set; }
    IPEndPoint IpPoint { get; set; }

    public Listener(string host, int port)
    {
        this.Host = host;
        this.Port = port;
        this.IpPoint = IPEndPoint.Parse($"{Host}:{Port}");
        this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public void StartListening()
    {
        if (Listening) return;

        this.socket.Bind(IpPoint);
        this.socket.Listen(100);
        Console.WriteLine($"Server listening on: {IpPoint}");

        socket.BeginAccept(new AsyncCallback(ListenCallback), this.socket);
        this.Listening = true;
    }

    void ListenCallback(IAsyncResult result)
    {
        try
        {
            Socket handler = this.socket.EndAccept(result);
            SocketAccepted?.Invoke(handler);
            this.socket.BeginAccept(ListenCallback, this.socket);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public delegate void SocketAcceptedHandler(Socket socket);
    public event SocketAcceptedHandler? SocketAccepted;
}
