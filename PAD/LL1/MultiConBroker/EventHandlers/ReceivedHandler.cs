using System.Net.Sockets;

namespace MultiConBroker;

public class ReceivedHandler : EventArgs
{
    public Socket ReceivedSocket { get; private set; }
    public byte[] Data { get; private set; }

    public ReceivedHandler(Socket socket, byte[] data)
    {
        this.ReceivedSocket = socket;
        this.Data = (byte[])data.Clone();
    }
}