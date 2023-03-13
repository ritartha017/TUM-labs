using Protocols.AbstractProducts;

namespace Protocols.AbstractFactory;

abstract class Chat
{
    public abstract void SendMessage(string message);
    public abstract Socket GetSocket();
}
