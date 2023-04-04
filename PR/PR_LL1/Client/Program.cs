using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Client;

class Program
{
    static void Main(string[] args)
    {
        Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1994);

        try
        {
            sck.Connect(localEndPoint);
        }
        catch
        {
            Console.Write("Unable to connect to remote endpoint!\r\n");
            Main(args);
        }

        while (true)
        {
            try
            {
                Console.Write("Enter text: ");
                string msg = Console.ReadLine();

                byte[] msgBuffer = Encoding.Default.GetBytes(msg);
                sck.Send(msgBuffer, 0, msgBuffer.Length, 0);

                byte[] buffer = new byte[255];
                int rec = sck.Receive(buffer, 0, buffer.Length, 0);
                Array.Resize(ref buffer, rec);

                Console.Write("Data sent!\r\n");
                Console.WriteLine("Received: {0}", Encoding.Default.GetString(buffer));
            }
            catch
            {
                Console.WriteLine("Something went wrong! The server is down");
                sck.Close();
            }
        }
    }
}