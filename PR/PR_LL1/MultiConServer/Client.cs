namespace MultiConServer;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Client
{
    public string Id { get; private set; }
    public IPEndPoint? EndPoint { get; private set; }

    readonly Socket socket;

    public event ClientReceivedHandler? Received;
    public delegate void ClientReceivedHandler(Client sender, byte[] data);

    public event ClientDisconnectedHandler? Disconnected;
    public delegate void ClientDisconnectedHandler(Client sender);

    public Client(Socket accepted)
    {
        this.socket = accepted;
        this.Id = Guid.NewGuid().ToString();
        EndPoint = (IPEndPoint?)socket.RemoteEndPoint;
        BeginReceive();
    }

    private void BeginReceive()
    {
        socket.BeginReceive(new byte[] { 0 }, 0, 0, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
    }

    void ReceiveCallback(IAsyncResult result)
    {
        try
        {
            this.socket.EndReceive(result);
            byte[] buffer = new byte[8192];
            int rec = this.socket.Receive(buffer, buffer.Length, 0);
            if (rec < buffer.Length)
                Array.Resize(ref buffer, rec);
            Received?.Invoke(this, buffer);
            BeginReceive();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            CloseSocketConnection();
            this.Disconnected?.Invoke(this);
        }
    }

    public void SendMessage(string message)
    {
        var status = this.socket.Send(Encoding.Default.GetBytes(message));
        if (status > 0)
            return;
        throw new SocketException();
    }

    public void CloseSocketConnection()
    {
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
        Environment.Exit(0);
    }
}
