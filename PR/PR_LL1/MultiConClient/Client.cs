using System.Net.Sockets;
using System.Text;

namespace MultiConClient;

class Client
{
    public Socket socket;
    readonly string host;
    readonly int port;

    static Socket Socket()
        => new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    public Client(string host, int port)
    {
        this.host = host;
        this.port = port;
        socket = Socket();
    }

    public async Task ConnectSocketAsync()
    {
        try
        {
            await socket.ConnectAsync(host, port);
            new Thread(() =>
            {
                Read();
            }).Start();
            Console.WriteLine($@"Connected to {host}
                                 Connection address {socket.RemoteEndPoint}
                                 App address {socket.LocalEndPoint}");
        }
        catch (SocketException ex)
        {
            Console.WriteLine($"Failed to connect to the {host}. {0}", ex.Message);
            Close();
        }
    }

    async void Read()
    {
        while (true)
        {
            try
            {
                byte[] data = new byte[512];
                int bytes = await socket.ReceiveAsync(data);
                string message = Encoding.UTF8.GetString(data, 0, bytes);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Server: ");
                Console.ResetColor();
                Console.WriteLine(message);
            }
            catch
            {
                Console.WriteLine("DISCONNECTED FROM SERVER!");
                Close();
                break;
            }
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
        Environment.Exit(0);
    }

    public void SendMessage(string message)
    {
        var status = this.socket.Send(Encoding.Default.GetBytes(message));
        if (status > 0)
            return;
        throw new SocketException();
    }
}
