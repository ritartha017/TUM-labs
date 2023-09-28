namespace MultiConBroker;

public class DisconnectedHandler : EventArgs
{
    public Publisher Publisher { get; private set; }

    public DisconnectedHandler(Publisher publisher)
    {
        Publisher = publisher;
    }
}