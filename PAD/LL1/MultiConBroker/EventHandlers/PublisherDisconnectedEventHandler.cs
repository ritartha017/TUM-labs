namespace MultiConBroker;

public class PublisherDisconnectedHandler : EventArgs
{
    public Publisher Publisher { get; private set; }

    public PublisherDisconnectedHandler(Publisher p)
    {
        Publisher = p;
    }
}