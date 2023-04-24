using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Management;
using System.Diagnostics;
using System;

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
                Console.WriteLine("ipv4 DNS Servers ............................. : {0}",
                    ip4.ToString());
            }
            foreach (IPAddress ip6 in dnsServers.Where(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6))
            {
                Console.WriteLine("ipv6 DNS Servers ............................. : {0}",
                    ip6.ToString());
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

void SetDNS(string ipServer)
{
    using var psi = Process.Start("/bin/bash", $"-c \"networksetup -setdnsservers Wi-Fi {ipServer}\"");
    psi.WaitForExit();
}

void ShowDNSServer()
{
    using var psi = Process.Start("/bin/bash", "-c \"scutil --dns | grep 'nameserver\\[[0-9]*\\]'\"");
    psi.WaitForExit();
}

string stackoverflowDomain = "stackoverflow.com";
string randomIp = "204.79.197.200";

PPrint(() => SetDNS("192.168.1.1"));
Thread.Sleep(1000);
PPrint(() => DisplayDnsAdresses());

PPrint(() => SetDNS("8.8.8.8"));
Thread.Sleep(1000);
PPrint(() => DisplayDnsAdresses());

PPrint(() => SetDNS("0.0.0.0"));
Thread.Sleep(1000);
PPrint(() => DisplayDnsAdresses());

try
{
    PPrint(() => HostName2IP(stackoverflowDomain));
    PPrint(() => IP2HostName(randomIp));
}
catch(SocketException se)
{
    Console.WriteLine(se.ToString());
}
catch (Exception e)
{
    Console.WriteLine(e.ToString());
}

Console.ReadKey();