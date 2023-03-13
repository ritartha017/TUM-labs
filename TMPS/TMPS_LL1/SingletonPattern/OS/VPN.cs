namespace VPN;

class VPN
{
    private static VPN instance;

    public string ServerCountryName { get; private set; }

    protected VPN(string serverCountryName)
    {
        this.ServerCountryName = serverCountryName;
    }

    public static VPN GetServerInstance(string serverCountryName)
    {
        instance ??= new VPN(serverCountryName);
        return instance;
    }
}