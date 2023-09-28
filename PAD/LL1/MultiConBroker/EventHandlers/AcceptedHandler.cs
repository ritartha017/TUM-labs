using System.Net.Sockets;

namespace MultiConBroker;

class AcceptedHandler : EventArgs
{
    public Socket Accepted { get; private set; }

    public AcceptedHandler(Socket socket)
    {
        Accepted = socket;
    }
}