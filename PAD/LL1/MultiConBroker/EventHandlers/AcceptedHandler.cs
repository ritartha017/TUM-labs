using System.Net.Sockets;

namespace MultiConBroker;

public class AcceptedHandler : EventArgs
{
    public Socket Accepted { get; private set; }

    public AcceptedHandler(Socket socket)
    {
        Accepted = socket;
    }
}