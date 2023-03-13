using Protocols.AbstractFactory;
using Protocols.AbstractProducts;
using Protocols.ConcreteProducts;

namespace Protocols.ConcreteFactories;

class UDPChat : Chat
{
    public UDPChat()
    {
        Console.WriteLine("A new udp chat was created.");
    }

    public override Socket GetSocket()
    {
        return new TCPSocket();
    }

    public override void SendMessage(string message)
    {
        Console.WriteLine("");
    }
}
