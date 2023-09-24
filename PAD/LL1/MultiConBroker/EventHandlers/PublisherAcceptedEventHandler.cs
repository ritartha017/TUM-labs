using System.Net.Sockets;

namespace MultiConBroker;

class PublisherAcceptedEventHandler : EventArgs
{
    public Socket Accepted { get; private set; }

    public PublisherAcceptedEventHandler(Socket s)
    {
        Accepted = s;
    }
}