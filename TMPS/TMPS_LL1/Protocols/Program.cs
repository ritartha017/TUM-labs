using Protocols.AbstractFactory;
using Protocols.ConcreteFactories;

class Program
{
    static void Main(string[] args)
    {
        Chat chat = new TCPChat();
        chat = new UDPChat();

        Console.ReadLine();
    }
}