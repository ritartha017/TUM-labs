using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server2;

class Program
{
    static void Main(string[] args)
    {
        Socket sck = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        sck.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1994));
        sck.Listen(0);

        Socket accepted = sck.Accept();

        byte[] buffer = Encoding.Default.GetBytes("Hello client");
        accepted.Send(buffer, 0, buffer.Length, 0);

        while (true)
        {
            try
            {
                buffer = new byte[255];
                int rec = accepted.Receive(buffer, 0, buffer.Length, 0);
                if (rec == 0) throw new SocketException();
                Array.Resize(ref buffer, rec);
                Console.WriteLine("Received: {0}", Encoding.Default.GetString(buffer));
            }
            catch
            {
                sck.Close();
                accepted.Close();
            }
        }
    }

}

