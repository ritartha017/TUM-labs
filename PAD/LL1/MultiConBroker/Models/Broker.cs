using System.Net;
using System.Net.Sockets;

namespace MultiConBroker;

class Broker
{
    Socket socket;
    private readonly int CONNS_LIMIT = 10;

    public bool Listening { get; private set;  }
    public int Port { get; private set; }
    public string Host { get; private set; }

    public Broker(string host, int port)
    {
        Host = host;
        Port = port;
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public void Start()
    {
        if (Listening)
            return;
        socket.Bind(new IPEndPoint(0, Port));
        socket.Listen(CONNS_LIMIT);
        socket.BeginAccept(AcceptedCallback, null);
        Listening = true;
    }

    public void Stop()
    {
        if (!Listening)
            return;
        socket.Close();
        socket.Dispose();
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    void AcceptedCallback(IAsyncResult ar)
    {
        try
        {
            Socket s = this.socket.EndAccept(ar);
            SocketAccepted?.Invoke(this, new AcceptedHandler(s));
            this.socket.BeginAccept(AcceptedCallback, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public event EventHandler<AcceptedHandler> SocketAccepted;
}
