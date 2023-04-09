using ProxyPattern.Interface;

namespace ProxyPattern.RealObject;

class Internet : IInternet
{
    public void ConnectTo(string serverhost)
    {
        Console.WriteLine("Connecting to " + serverhost);
    }
}
