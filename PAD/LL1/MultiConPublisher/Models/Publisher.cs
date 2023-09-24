using System.Net;
using System.Net.Sockets;
using Common.Data;

namespace Publisher;

public class Publisher
{
    private const int connectionTimeOutms = 5000;
    private Socket theDevSock;
    private SocketState sockState;

    public Publisher()
	{
        theDevSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sockState = SocketState.Disconnected;
    }

    public bool StartConnect(string ipAddress = "192.168.1.10", int port = 1000)
    {
        try
        {
            Console.WriteLine("Start connect to server...");
            var endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            IAsyncResult asyncResult = this.theDevSock.BeginConnect(endPoint, ConnectCallback, theDevSock);
            bool flag = asyncResult.AsyncWaitHandle.WaitOne(connectionTimeOutms, true);
            if (!flag) throw new TimeoutException("The waiting was too long.");
            sockState = SocketState.Connecting;
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
            theDevSock = (Socket)asyncResult.AsyncState;
            theDevSock.EndConnect(asyncResult);
            if (theDevSock != null && theDevSock.Connected)
            {
                sockState = SocketState.Connected;
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
            theDevSock.Send(data);
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
            if (theDevSock != null && theDevSock.Connected)
            {
                theDevSock.Shutdown(SocketShutdown.Both);
                theDevSock.Close();
                theDevSock.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        theDevSock = null;
        sockState = SocketState.Disconnected;
    }
}
