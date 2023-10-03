using System.Net;
using System.Net.Sockets;
using System.Text;
using Common.Data;
using MultiConSubscriber.EventHandlers;

namespace MultiConSubscriber;

public class Subscriber
{
    private const int connectionTimeOutms = 5000;
    private Socket socket;
    private string topic;
    private SocketState socketState;

    public Subscriber(string topic)
    {
        this.topic = topic;
        this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        this.socketState = SocketState.Disconnected;
    }

    public bool StartConnect(string ipAddress, int port)
    {
        try
        {
            Console.WriteLine("Start connect to server...");
            var endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            IAsyncResult asyncResult = this.socket.BeginConnect(endPoint, ConnectedCallback, socket);
            bool flag = asyncResult.AsyncWaitHandle.WaitOne(connectionTimeOutms, true);
            if (!flag) throw new TimeoutException("The waiting was too long.");
            socketState = SocketState.Connecting;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"#### Unable to connect to server...{ex.Message}");
        }
        CloseSocket();
        return false;
    }

    void ConnectedCallback(IAsyncResult asyncResult)
    {
        try
        {
            socket = (Socket)asyncResult.AsyncState;
            socket.EndConnect(asyncResult);
            if (socket != null && socket.Connected)
            {
                socketState = SocketState.Connected;
                Console.WriteLine("Subscriber is connected to broker...");
                Connected?.Invoke(this, new ConnectedHandler(socket));
                return;
            }
            Console.WriteLine("Failed to connect to broker...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Subscriber not connected. {ex.ToString()}");
        }
        CloseSocket();
    }

    public void Subscribe()
    {
        var message = Encoding.UTF8.GetBytes(CommonConstants.SubscribePrefix + this.topic);
        try
        {
            socket.Send(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Could not send data. {ex.Message}");
        }
    }

    public void CloseSocket()
    {
        try
        {
            if (socket != null && socket.Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        socket = null;
        socketState = SocketState.Disconnected;
    }

    public event EventHandler<ConnectedHandler> Connected;
    public event EventHandler<ReceivedHandler> Received;
}