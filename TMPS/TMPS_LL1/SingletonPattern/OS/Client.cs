namespace VPN;

class Client
{
    static void Main()
    {
        Computer comp = new();
        comp.LaunchVPN("US");
        Console.WriteLine(comp.VPN.ServerCountryName);

        comp.VPN = VPN.GetServerInstance("Poland");
        Console.WriteLine(comp.VPN.ServerCountryName);

        Console.ReadLine();
    }
}