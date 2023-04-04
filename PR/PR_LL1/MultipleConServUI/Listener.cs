using System.Net.Sockets;
using System.Net;

namespace MultipleConServUI;

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

    public void Start()
    {
        if (Listening) return;

        this.socket.Bind(IpPoint);
        this.socket.Listen(0);
        this.socket.BeginAccept(Callback, null);
        this.Listening = true;
    }

    public void Stop()
    {
        if (!Listening) return;

        try
        {
            socket.Shutdown(SocketShutdown.Both);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            this.socket.Close();
            this.socket.Dispose();
        }
        this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    void Callback(IAsyncResult ar)
    {
        try
        {
            Socket socket = this.socket.EndAccept(ar);
            SocketAccepted?.Invoke(this.socket);
            this.socket.BeginAccept(Callback, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public delegate void SocketAcceptedHandler(Socket socket);
    public event SocketAcceptedHandler? SocketAccepted;
}