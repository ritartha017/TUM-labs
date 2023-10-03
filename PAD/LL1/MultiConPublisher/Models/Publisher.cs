using System.Net;
using System.Net.Sockets;
using Common.Data;

namespace MulticonPublisher;

public class Publisher
{
    private const int connectionTimeOutms = 5000;
    private Socket socket;
    private SocketState socketState;

    public Publisher()
	{
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        socketState = SocketState.Disconnected;
    }

    public bool StartConnect(string ipAddress, int port)
    {
        try
        {
            Console.WriteLine("Start connect to server...");
            var endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            IAsyncResult asyncResult = this.socket.BeginConnect(endPoint, ConnectCallback, socket);
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

    void ConnectCallback(IAsyncResult asyncResult)
    {
        try
        {
            socket = (Socket)asyncResult.AsyncState;
            socket.EndConnect(asyncResult);
            if (socket != null && socket.Connected)
            {
                socketState = SocketState.Connected;
                Console.WriteLine("Server is connected...");
                return;
            }
            Console.WriteLine("Failed to connect to server...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Publisher not connected. {ex.ToString()}");
        }
        CloseSocket();
    }

    public void Send(byte[] data)
    {
        try
        {
            socket.Send(data);
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
}
