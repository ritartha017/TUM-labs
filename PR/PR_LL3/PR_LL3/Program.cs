using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Management;

void HostName2IP(string hostname)
{
    IPAddress[] ipaddress = Dns.GetHostAddresses(hostname);
    Console.WriteLine("IPs of hostname are:");
    foreach (IPAddress ip4 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
    {
        Console.WriteLine($"IPv4.....{ip4.ToString()}");
    }
    foreach (IPAddress ip6 in ipaddress.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
    {
        Console.WriteLine($"IPv6.....{ip6.ToString()}");
    }
}

void IP2HostName(string ipAddress)
{
    IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
    var hostname = hostEntry.HostName;
    Console.WriteLine($"Hostname of {ipAddress} is {hostname}.");
}

static void DisplayDnsAdresses()
{
    NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
    foreach (NetworkInterface networkInterface in interfaces)
    {
        if (networkInterface.OperationalStatus == OperationalStatus.Up)
        {
            IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
            IPAddressCollection dnsServers = ipProperties.DnsAddresses;
            if (dnsServers.Count < 0) return;
            foreach (IPAddress ip4 in dnsServers.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork))
            {
                Console.WriteLine("DNS Servers ............................. : {0}",
                    ip4.ToString());
            }
            foreach (IPAddress ip6 in dnsServers.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
            {
                Console.WriteLine("DNS Servers ............................. : {0}",
                    ip6.ToString());
            }
        }
    }
}

static NetworkInterface GetActiveEthernetOrWifiNetworkInterface()
{
    var Nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
        a => a.OperationalStatus == OperationalStatus.Up &&
        (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
        a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));

    return Nic;
}


static void SetDNS(string DnsString)
{
    string[] Dns = { DnsString };
    var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
    if (CurrentInterface == null) return;

    ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
    ManagementObjectCollection objMOC = objMC.GetInstances();
    foreach (ManagementObject objMO in objMOC)
    {
        if ((bool)objMO["IPEnabled"])
        {
            if (objMO["Description"].ToString().Equals(CurrentInterface.Description))
            {
                ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                if (objdns != null)
                {
                    objdns["DNSServerSearchOrder"] = Dns;
                    objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                }
            }
        }
    }
}

bool PPrint(Action funcToRun)
{
    funcToRun();
    Console.WriteLine();
    return true;
}

string stackoverflowDomain = "stackoverflow.com";
string randomIp = "204.79.197.200";

PPrint(() => DisplayDnsAdresses());
SetDNS("127.0.0.1");
PPrint(() => DisplayDnsAdresses());
PPrint(() => HostName2IP(stackoverflowDomain));
PPrint(() => IP2HostName(randomIp));

Console.ReadKey();