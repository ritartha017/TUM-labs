namespace Protocols.ConcreteProducts;

using Protocols.AbstractProducts;

class TCPSocket : Socket
{
    public override void Close()
    {
        //
    }

    public override void Open()
    {
        Console.WriteLine("TCP ");
    }

    public override String Receive()
    {
        return "Message from TCP chat server";
    }

    public override void Send(string messageToSend)
    {
        throw new NotImplementedException();
    }
}
