namespace Protocols.ConcreteFactories;

using Protocols.AbstractFactory;
using Protocols.AbstractProducts;
using Protocols.ConcreteProducts;

class TCPChat : Chat
{
    public TCPChat()
    {
        Console.WriteLine("A new tcp chat was created.");
    }

    public override Socket GetSocket()
    {
        return new TCPSocket();
    }

    public override void SendMessage(string messageToSend)
    {
        Socket socket = GetSocket();
        socket.Open();
        socket.Send(messageToSend);
        var messageReceived = socket.Receive();
        socket.Close();
    }
}
