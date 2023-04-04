using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Server;

class Program
{
    static void Main(string[] args)
    {
        Socket sck = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // bind our socket to a certain endpoint
        // 0 is the same as IPAddress.Any
        sck.Bind(new IPEndPoint(0, 1234));
        sck.Listen(100);
        
        // this is going to make a blocking call and wait for an available socket that attempts to connect
        // and will thansfer the socker over the "accepted" variable
        Socket accepted = sck.Accept();
        // the default buffer size is 8192 - the nr of bytes that can be received at one time
        byte[] Buffer = new byte[accepted.SendBufferSize];
        // this will wait for a buffer , receive it and transfer it to Buffer variable
        // and in bytesRead = the nr of bytes that were sent or read
        int bytesRead = accepted.Receive(Buffer);
        byte[] formatted = new byte[bytesRead];
        for (int i = 0; i < bytesRead; i++)
        {
            formatted[i] = Buffer[i];
        }
        string strData = Encoding.ASCII.GetString(formatted);
        Console.Write(strData + "\r\n");
        Console.Read();
        sck.Close();
        accepted.Close();
    }

}

