using Protocols.AbstractProducts;

namespace Protocols.ConcreteProducts;

class UDPSocket : Socket
{
    public override void Close()
    {
        //
    }

    public override void Open()
    {
        //
    }

    public override String Receive()
    {
        return "Some string from udpsocket.";
    }


    public override void Send(string messageToSend)
    {
        // throw new NotImplementedException();
    }
}
