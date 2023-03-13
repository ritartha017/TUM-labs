namespace VPN;

class Computer
{
    public VPN VPN { get; set; }
    public void LaunchVPN(string serverCountryName)
    {
        VPN = VPN.GetServerInstance(serverCountryName);
    }
}
