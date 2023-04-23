using System;             // For Console and Exception classes
using System.Net;         // For IPAddress class
using System.Net.Sockets; // For Socket class
using System.Reflection;
using System.Text;

class MCReceive
{
    const int MIN_PORT = 1024;  // min port value
    const int MAX_PORT = 65535; // max port value

    public static int Main()
    {

        Socket sock;           // Multicast socket
        IPAddress mcIP;           // Multicast group to join
        int mcPort;         // Port to receive on
        IPEndPoint receivePoint;   // IP end point
        int MAX_LEN = 1024;   // Max receive buffer size
        System.Boolean done = false;     // loop variable

        string ip = "225.0.0.36";
        string port = "15000";
        Console.WriteLine(ip, port);

        mcIP = ValidateAddress(ip);
        if (!ValidatePortNumber(port, out mcPort)) return 1;

        try
        {
            // Create the Socket
            sock = new Socket(AddressFamily.InterNetwork,
                              SocketType.Dgram,
                              ProtocolType.Udp);
            // Set the reuse address option
            sock.SetSocketOption(SocketOptionLevel.Socket,
                                 SocketOptionName.ReuseAddress, 1);
            // Create an IPEndPoint and bind to it
            IPEndPoint ipep = new(IPAddress.Any, mcPort);
            sock.Bind(ipep);
            // Add membership in the multicast group
            sock.SetSocketOption(SocketOptionLevel.IP,
                                 SocketOptionName.AddMembership,
                                 new MulticastOption(mcIP, IPAddress.Any));
            // Create the EndPoint class
            receivePoint = new IPEndPoint(IPAddress.Any, 0);
            EndPoint tempReceivePoint = (EndPoint)receivePoint;
            while (!done)
            {
                byte[] recData = new byte[MAX_LEN];
                // Receive the multicast packets
                int length = sock.ReceiveFrom(recData, 0, MAX_LEN, SocketFlags.None, ref tempReceivePoint);
                // Format and output the received data packet
                ASCIIEncoding encode = new();
                Console.WriteLine("Received " + length + " bytes from " + tempReceivePoint.ToString() + ": " + encode.GetString(recData, 0, length));
                using Socket sender = new(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                Console.WriteLine("Type message and press Enter");
                while (true)
                {
                    var message = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(message)) break;
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    sender.SendTo(data, tempReceivePoint);
                }
            }
            // Drop membership
            sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.DropMembership, new MulticastOption(mcIP, IPAddress.Any));
            // Close the socket
            sock.Close();
        }
        catch (SocketException se)
        {
            Console.WriteLine("Socket Exception: " + se.ToString());
            return 1;
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("Exception: " + e.ToString());
            return 1;
        }
        return 0;
    }

    public static IPAddress ValidateAddress(string ip)
    {
        IPAddress mcIP;
        // Validate the input multicast IP address
        try
        {
            mcIP = IPAddress.Parse(ip);
        }
        catch (Exception)
        {
            Console.Error.WriteLine("Invalid IP Address specified.");
            return null;
        }
        return mcIP;
    }

    public static bool ValidatePortNumber(string port, out int mcPort)
    {
        // Validate the input port number
        try
        {
            mcPort = Int32.Parse(port);
        }
        catch (Exception)
        {
            Console.Error.WriteLine("Invalid Port specified.");
            mcPort = 0;
            return false;
        }
        if ((mcPort < MIN_PORT) || (mcPort > MAX_PORT))
        {
            Console.Error.WriteLine("Invalid Port specified.");
            Console.Error.WriteLine("Port must be between " + MIN_PORT
                                    + " and " + MAX_PORT);
            return false;
        }
        return true;
    }
}
