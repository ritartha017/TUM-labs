using System.Net;
using System.Net.Sockets;

namespace MultiConBroker;

class Broker
{
    Socket s;
    private readonly int CONNS_LIMIT = 10;

    public bool Listening { get; private set;  }
    public int Port { get; private set; }

    public Broker(int port)
    {
        Port = port;
        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public void Start()
    {
        if (Listening)
            return;
        s.Bind(new IPEndPoint(0, Port));
        s.Listen(CONNS_LIMIT);
        s.BeginAccept(AcceptedCallback, null);
        Listening = true;
    }

    public void Stop()
    {
        if (!Listening)
            return;
        s.Close();
        s.Dispose();
        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    void AcceptedCallback(IAsyncResult ar)
    {
        try
        {
            Socket s = this.s.EndAccept(ar);
            SocketAccepted?.Invoke(this, new PublisherAcceptedEventHandler(s));
            this.s.BeginAccept(AcceptedCallback, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public event EventHandler<PublisherAcceptedEventHandler> SocketAccepted;
}
