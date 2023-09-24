using System.Net.Sockets;

namespace MultiConSubscriber;

public class SubscriberConnectedEventHandler : EventArgs
{
    public Socket Socket { get; private set; }

    public SubscriberConnectedEventHandler(Socket socket)
	{
        this.Socket = socket;
    }
}