using System.Net.Sockets;

namespace MultiConBroker;

public class AcceptedHandler : EventArgs
{
    public Socket AcceptedSocket { get; private set; }

    public AcceptedHandler(Socket socket)
    {
        this.AcceptedSocket = socket;
    }
}