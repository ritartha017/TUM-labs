namespace MultipleConServUI;

using System;
using System.Net;
using System.Net.Sockets;

class Client
{
    public string Id { get; private set; }
    public IPEndPoint? EndPoint { get; private set; }
    Socket socket;

    public delegate void ClientReceivedHandler(Client sender, byte[] data);
    public delegate void ClientDisconnectedHandler(Client sender);

    public event ClientReceivedHandler? Received;
    public event ClientDisconnectedHandler? Disconnected;

    public Client(Socket accepted)
    {
        this.socket = accepted;
        this.Id = Guid.NewGuid().ToString();
        this.EndPoint = (IPEndPoint?)this.socket.RemoteEndPoint;
        this.socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);
    }

    void Callback(IAsyncResult ar)
    {
        try
        {
            this.socket.EndReceive(ar);
            byte[] buffer = new byte[8192];
            int rec = this.socket.Receive(buffer, buffer.Length, 0);
            if (rec < buffer.Length)
            {
                Array.Resize(ref buffer, rec);
            }

            if (this.Received != null)
            {
                this.Received(this, buffer);
                this.socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Close();
            this.Disconnected?.Invoke(this);
        }
    }

    public void Close()
    {
        try
        {
            this.socket.Shutdown(SocketShutdown.Both);
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
    }
}
