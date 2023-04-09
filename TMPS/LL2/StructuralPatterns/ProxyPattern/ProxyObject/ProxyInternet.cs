using ProxyPattern.Interface;
using ProxyPattern.RealObject;

namespace ProxyPattern.ProxyObject;

class ProxyInternet : IInternet
{

    private Internet internet = new();
    private static List<string> bannedSites = new() { "abc.com", "def.com", "ijk.com", "lnm.com" };

    public void ConnectTo(string serverhost)
    {
        if (bannedSites.Contains(serverhost))
            throw new Exception("Access Denied");
        internet.ConnectTo(serverhost);
    }
}
