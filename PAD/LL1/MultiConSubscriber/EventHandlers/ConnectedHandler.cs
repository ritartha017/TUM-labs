using System.Net.Sockets;

namespace MultiConSubscriber;

public class ConnectedHandler : EventArgs
{
    public Socket Socket { get; private set; }

    public ConnectedHandler(Socket socket)
	{
        this.Socket = socket;
    }
}