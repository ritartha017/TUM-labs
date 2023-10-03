using System.Net.Sockets;

namespace MultiConBroker;

public class DisconnectedHandler : EventArgs
{
    public Socket DisconnectedSocket { get; private set; }

    public DisconnectedHandler(Socket socket)
    {
        this.DisconnectedSocket = socket;
    }
}