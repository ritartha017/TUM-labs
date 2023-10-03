using System.Net.Sockets;

namespace MultiConSubscriber.EventHandlers;

public class ReceivedHandler : EventArgs
{
    public byte[] data { get; private set; }

    public ReceivedHandler(byte[] data)
    {
        this.data = (byte[])data.Clone();
    }
}