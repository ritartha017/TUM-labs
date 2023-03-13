namespace Protocols.AbstractProducts;

abstract class Socket
{
    public abstract void Open();
    public abstract void Send(String messageToSend);
    public abstract void Close();
    public abstract String Receive();
}
