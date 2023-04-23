using System;             // For Console and Exception classes
using System.Net;         // For IPAddress class
using System.Net.Sockets; // For Socket class

class MCSend
{
    const int MIN_PORT = 1024;  // min port value
    const int MAX_PORT = 65535; // max port value

    public static int Main()
    {

        Socket sock;       // Multicast socket
        IPAddress mcIP;       // Destination multicast addr
        int mcPort;     // Destination port
        IPEndPoint ipep;       // IP end point
        int ttl = 1;      // time to live (1 hop)
        Boolean done = false; // loop variable

        string ip = "225.0.0.36";
        string port = "15000";
        Console.WriteLine(ip, port);

        // Validate the input multicast IP address
        try
        {
            mcIP = IPAddress.Parse(ip);
        }
        catch (Exception)
        {
            Console.Error.WriteLine("Invalid IP Address specified.");
            return 1;
        }

        // Validate the input port number
        try
        {
            mcPort = Int32.Parse(port);
        }
        catch (Exception)
        {
            Console.Error.WriteLine("Invalid Port specified.");
            return 1;
        }
        if ((mcPort < MIN_PORT) || (mcPort > MAX_PORT))
        {
            Console.Error.WriteLine("Invalid Port specified.");
            Console.Error.WriteLine("Port must be between " + MIN_PORT
                                    + " and " + MAX_PORT);
            return 1;
        }

        // Create an IP endpoint class instance
        ipep = new IPEndPoint(mcIP, mcPort);

        try
        {

            // Create the Socket
            sock = new Socket(AddressFamily.InterNetwork,
                              SocketType.Dgram,
                              ProtocolType.Udp);

            // Set the Time to Live                          
            sock.SetSocketOption(SocketOptionLevel.IP,
                                 SocketOptionName.MulticastTimeToLive,
                                 ttl);

            Console.WriteLine("Begin typing " +
                              "(return to send, ctrl-C to quit):");

            while (!done)
            {

                // Read and format input from the terminal
                string str = Console.ReadLine();

                System.Text.ASCIIEncoding encode =
                                  new System.Text.ASCIIEncoding();

                byte[] inputToBeSent = encode.GetBytes(str);

                // Send the data packet
                sock.SendTo(inputToBeSent, 0, inputToBeSent.Length,
                            SocketFlags.None, ipep);
            }

            // Close the socket
            sock.Close();

        }
        catch (SocketException se)
        {
            Console.Error.WriteLine("Socket Exception: "
                                    + se.ToString());
            return 1;
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("Exception: "
                                    + e.ToString());
            return 1;
        }
        return 0;
    }
}
