namespace MultipleConServUI;

using System;
using System.Net.Sockets;

class Program
{
    static Listener listener;

    static void Main()
    {
        listener = new Listener("127.0.0.1", 8);
        listener.SocketAccepted += new Listener.SocketAcceptedHandler(Listener_SocketAccepted);
        listener.Start();

        Console.Read();
    }

    private static void Listener_SocketAccepted(Socket socket)
    {
        Console.WriteLine("New Connection: {0}\n{1}\n===========", socket.RemoteEndPoint, DateTime.Now);
    }
}
