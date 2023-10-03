using System.Net;
using System.Net.Sockets;
using MultiConSubscriber.EventHandlers;

namespace MultiConSubscriber.Models;

public class Broker
{
    public IPEndPoint? EndPoint { get; private set; }
    private Socket socket;

    public Broker(Socket socket)
    {
        this.socket = socket;
        EndPoint = (IPEndPoint?)this.socket.RemoteEndPoint;
        this.socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
    }

    void ReceivedCallback(IAsyncResult ar)
    {
        try
        {
            socket.EndReceive(ar, out SocketError response);

            var buff = new byte[8192];
            var rec = socket.Receive(buff, buff.Length, 0);

            if (rec < buff.Length)
                Array.Resize<byte>(ref buff, rec);
            if (buff.Length <= 0)
            {
                Close();
                return;
            }

            Received?.Invoke(this, new ReceivedHandler(buff));

            socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, ReceivedCallback, null);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            Close();
        }
    }

    public void Close()
    {
        socket.Close();
        socket.Dispose();
    }

    public event EventHandler<ReceivedHandler> Received;
}

