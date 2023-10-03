namespace MultiConBroker;

public class ReceivedHandler : EventArgs
{
    public Publisher Publisher { get; private set; }
    public byte[] data { get; private set; }

    public ReceivedHandler(Publisher p, byte[] data)
    {
        Publisher = p;
        this.data = (byte[])data.Clone();
    }
}